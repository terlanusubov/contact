using Contact.Application.CQRS.Core;
using Contact.Application.Interfaces;
using Contact.Application.Models.Request;
using Contact.Application.Models.Response;
using Contact.Domain.DTOs;
using Contact.Domain.Entities;
using Contact.Domain.Enums;
using Contact.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Services
{
    public class UserContactService : IUserContactService
    {
        private readonly ApplicationDbContext _context;

        public UserContactService(ApplicationDbContext context)
          => _context = context;

        public async Task<ApiResult<CreateUserContactResponse>> CreateUserContact(CreateUserContactRequest model, int userId)
        {

            var contact = await _context.UserContacts.FirstOrDefaultAsync(c => c.UserId == userId && c.Phone == model.Phone);

            if (contact != null)
                return ApiResult<CreateUserContactResponse>.Error(ErrorCodes.USER_CONTACT_IS_ALREADY_EXISTS);


            contact = new UserContact(model.Name,
                                      model.Surname,
                                      model.Phone,
                                      model.Email);

            contact.ConnectToUser(userId);

            await _context.UserContacts.AddAsync(contact);
            await _context.SaveChangesAsync();


            return ApiResult<CreateUserContactResponse>.OK(new CreateUserContactResponse
            {
                ContactId = contact.Id
            });

        }

        public async Task<ApiResult<DeleteUserContactResponse>> DeleteUserContact(int contactId, int userId)
        {
            var contact = await _context.UserContacts.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == contactId);

            if (contact == null)
                return ApiResult<DeleteUserContactResponse>.Error(ErrorCodes.USER_CONTACT_IS_NOT_EXISTS);


            _context.UserContacts.Remove(contact);
            await _context.SaveChangesAsync();

            return ApiResult<DeleteUserContactResponse>.OK(new DeleteUserContactResponse
            {
                ContactId = contactId
            });
        }

        public async Task<ApiResult<GetUserContactDetailByIdResponse>> GetUserContactDetailById(int contactId, int userId)
        {
            var contact = await _context
                                    .UserContacts
                                        .Where(c => c.UserId == userId && c.Id == contactId)
                                      .Select(c => new UserContactDto
                                      {
                                          ContactId = c.Id,
                                          Email = c.Email,
                                          Surname = c.Surname,
                                          Name = c.Name,
                                          Phone = c.Phone
                                      }).FirstOrDefaultAsync();

            if (contact == null)
                return ApiResult<GetUserContactDetailByIdResponse>.Error(ErrorCodes.USER_CONTACT_IS_NOT_EXISTS);

            var response = new GetUserContactDetailByIdResponse
            {
                Contact = contact
            };

            return ApiResult<GetUserContactDetailByIdResponse>.OK(response);
        }

        public async Task<ApiResult<GetUserContactResponse>> GetUserContacts(GetUserContactRequest model, int userId)
        {
            var user = await _context
                                .Users
                                    .FirstOrDefaultAsync(c => c.Id == userId);

            if (user == null)
                return ApiResult<GetUserContactResponse>.Error(ErrorCodes.USER_IS_NOT_EXISTS);



            var query = _context
                                    .UserContacts
                                        .Where(c =>

                    c.UserId == userId

                                        &&
                   (String.IsNullOrEmpty(model.Name) || (c.Name.StartsWith(model.Name) || c.Name.Contains(model.Name)))

                                        &&
                  (String.IsNullOrEmpty(model.Surname) || (c.Surname.StartsWith(model.Surname) || c.Surname.Contains(model.Surname)))

                                         &&
                 (String.IsNullOrEmpty(model.Email) || (c.Email.StartsWith(model.Email) || c.Email.Contains(model.Email)))
                                        &&

                 (String.IsNullOrEmpty(model.Phone) || (c.Phone.StartsWith(model.Phone) || c.Phone.Contains(model.Phone)))

                                        );



            var countQuery = query;

            int count = await countQuery.CountAsync();

            if (model.SortById == (byte)SortBy.Date)
                query = query.OrderByDescending(c => c.Created);
            else if (model.SortById == (byte)SortBy.Alphabetic)
                query = query.OrderByDescending(c => c.Name);

            if (model.Take != null)
                query = query.Skip((model.Page - 1) * (int)model.Take).Take((int)model.Take);


            var contacts = await query.Select(c => new UserContactDto
            {
                ContactId = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email,
                Phone = c.Phone
            }).ToListAsync();

            var response = new GetUserContactResponse
            {
                Contacts = contacts,
                Take = model.Take,
                Page = model.Page,
                TotalCount = count
            };


            return ApiResult<GetUserContactResponse>.OK(response);
        }

        public async Task<ApiResult<UpdateUserContactResponse>> UpdateUserContact(UpdateUserContactRequest model, int contactId, int userId)
        {
            var contact = await _context.UserContacts.FirstOrDefaultAsync(c => c.UserId == userId && c.Id == contactId);

            if (contact == null)
                return ApiResult<UpdateUserContactResponse>.Error(ErrorCodes.USER_CONTACT_IS_NOT_EXISTS);

            contact.Name = model.Name;
            contact.Surname = model.Suraname;
            contact.Email = model.Email;
            contact.Phone = model.Phone;
            contact.Updated = DateTime.Now;


            await _context.SaveChangesAsync();

            return ApiResult<UpdateUserContactResponse>.OK(new UpdateUserContactResponse
            {
                ContactId = contact.Id
            });

        }
    }
}

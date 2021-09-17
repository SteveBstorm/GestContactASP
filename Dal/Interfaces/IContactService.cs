using Dal.Entities;
using System.Collections.Generic;

namespace Dal.Interface
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContactByUserId(int UserId);
        void Insert(Contact c);
    }
}
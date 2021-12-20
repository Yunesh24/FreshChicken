using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreshChicken.Data;

namespace FreshChicken.Admin
{
    public class ContactListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string E_mail { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string SaveContactList(ContactListModel model)
        {
            string msg = "";
            FreshChickenEntities db = new FreshChickenEntities();
            var SaveContact = db.tbl_Contact.Where(p => p.Id == model.Id).FirstOrDefault();
            if (SaveContact == null)
            {
                var saveContactData = new tbl_Contact()
                {
                    Id = model.Id,
                    Name = model.Name,
                    E_mail = model.E_mail,
                    Phone= model.Phone,
                    Message=model.Message,
                };

                db.tbl_Contact.Add(saveContactData);
                db.SaveChanges();
                return msg;
            }
            else
            {
                SaveContact.Name = model.Name;
                SaveContact.E_mail = model.E_mail;
                SaveContact.Phone = model.Phone;
                SaveContact.Message = model.Message;
            };
            db.SaveChanges();
            msg = "updated successfully";
            return msg;
        }

        public List<ContactListModel> GetAddList()
        {
            FreshChickenEntities Db = new FreshChickenEntities();
            List<ContactListModel> lstContact = new List<ContactListModel>();
            var AddContactList = Db.tbl_Contact.ToList();
            if (AddContactList != null)
            {
                foreach (var Contact in AddContactList)
                {
                    lstContact.Add(new ContactListModel()
                    {
                        Id = Contact.Id,
                        Name = Contact.Name,
                        E_mail = Contact.E_mail,
                        Phone = Contact.Phone,
                        Message = Contact.Message,

                    });
                }
            }
            return lstContact;
                
        }
        public ContactListModel EditData(int Id)
        {
            string Message = "";
            ContactListModel model = new ContactListModel();
            FreshChickenEntities Db = new FreshChickenEntities();
            var editData = Db.tbl_Contact.Where(p => p.Id == Id).FirstOrDefault();
            if (editData != null)
            {
                model.Id = editData.Id;
                model.Name = editData.Name;
                model.E_mail= editData.E_mail;
                model.Phone = editData.Phone;
                model.Message = editData.Message;
            }

            Message = "Record Edited Successfully";
            return model;
        }
        public string deleteRecord(int Id)
        {
            string Message = "";
            FreshChickenEntities Db = new FreshChickenEntities();
            var deleteRecord = Db.tbl_Contact.Where(p => p.Id == Id).FirstOrDefault();
            if (deleteRecord != null)
            {
                Db.tbl_Contact.Remove(deleteRecord);
            };
            Db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }
    }
}

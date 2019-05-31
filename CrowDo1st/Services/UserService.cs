using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CrowDo1st
{

    public struct Result<T>
    {
        public int ErrorCodeId { get; set; }
        public string ErrorCodeString { get; set; }
        public T Data { get; set; }
    }

 

public class UserService : IUserService
    {
        public Result<bool>  CreateAccount(string name, string email, DateTime dateOfBirth, string location, string cardNumber) 
        {
            var context = new CrowDoDbContext();

            if (IsValidEmail(email) == false)
            {

                return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Invalid Email", Data = false };
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                    return new Result<bool> { ErrorCodeId =2, ErrorCodeString = "Null Or WhiteSpaceName", Data = false };
                }

            if (dateOfBirth.AddYears(18) > DateTime.Now)
            {

                return new Result<bool> { ErrorCodeId = 3, ErrorCodeString = "Not an adult", Data = false };
            }

            if (cardNumber.ToString().Length != 16)
            {

                return new Result<bool> { ErrorCodeId = 4, ErrorCodeString = "Invalid Card", Data = false };
            }

            var usrexist = context.Set<User>().Where(c => c.CardNumber == cardNumber).Any();
            if (usrexist)
            {

                return new Result<bool> { ErrorCodeId = 5, ErrorCodeString = "Card already exist, enter another card", Data = false };
            }


            var userexist = context.Set<User>().Where(u => u.Email == email).Any();


            if (userexist)
            {

                return new Result<bool> { ErrorCodeId = 6, ErrorCodeString = "Email belongs to another user", Data = false };
            }
            var user = new User
            {
                Name = name,
                Email = email,
                DateOfBirth = dateOfBirth,
                DateOfRegister = DateTime.Now,
                Location = location,
                CardNumber = cardNumber
            };
            context.Add(user);
            

            var rowsAffected = context.SaveChanges();
            if (rowsAffected < 1)
            {
                return new Result<bool> { ErrorCodeId = 6, ErrorCodeString = "Nothing saved", Data = false };
            }

            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "User Created", Data = true };
        }

        public Result<bool> DeleteAccount(string name, string email)
        {
            var context = new CrowDoDbContext();
            if (IsValidEmail(email) == false)
            {
                return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Invalid Email", Data = false };
            }
            var user = context.Set<User>().Where(User => User.Email == email).SingleOrDefault();
            
            if (user == null)
            {
                return new Result<bool> { ErrorCodeId = 2, ErrorCodeString = "Email does not exist", Data = false };
            }
            user.Activity = false;
            context.Update(user);
            
            var rowsAffected = context.SaveChanges();
            if (rowsAffected < 1)
            {
                return new Result<bool> { ErrorCodeId = 3, ErrorCodeString = "Nothing Saved", Data = false };
            }

            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Account Deactivated", Data = true };

        }

        public Result<bool> EditAccount(string name, string email, DateTime dateOfBirth, string location, string cardNumber)
        {
            var context = new CrowDoDbContext();

            if (IsValidEmail(email) == false)
            {
                return new Result<bool> { ErrorCodeId = 1, ErrorCodeString = "Invalid Email", Data = false };
            }
            var user = context.Set<User>().SingleOrDefault(User => User.Email == email);
            if (user == null)
            {
                return new Result<bool> { ErrorCodeId = 2, ErrorCodeString = "Email does not exists", Data = false };
            }
            user.Name = name;
            user.Email = email;
            user.DateOfBirth = dateOfBirth;
            user.DateOfRegister = DateTime.Now;
            user.Location = location;
            user.CardNumber = cardNumber;
            var rowsAffected = context.SaveChanges();
            if (rowsAffected < 1)
            {
                return new Result<bool> { ErrorCodeId = 3, ErrorCodeString = "Nothing Saved", Data = false };
            }
            return new Result<bool> { ErrorCodeId = 0, ErrorCodeString = "Changes have been saved", Data = false };
        }

        public bool IsValidEmail(string email)

        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            if (!email.Contains("@"))
            {
                return false; ;
            }
            return true;
        }





    }
}

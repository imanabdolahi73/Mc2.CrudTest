using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Common;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Services
{
    public interface ICustomerRepository
    {
        ResultDto Add(AddCustomerDto req);
        ResultDto Edit(EditCustomerDto req);
        ResultDto Delete(int id);
        ResultDto<List<Customer>> Get();
        ResultDto<Customer> GetById(int id);
        bool IsExist(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ITestDbContext _context;
        public CustomerRepository(ITestDbContext context)
        {
            _context = context;
        }

        public ResultDto Add(AddCustomerDto req)
        {
            try
            {
                Customer customer = new Customer()
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Email = req.Email,
                    DateOfBirth = req.DateOfBirth,
                    PhoneNumber = req.PhoneNumber,
                    BankAccountNumber = req.BankAccountNumber
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception e)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }

        public ResultDto Delete(int id)
        {
            try
            {
                if (IsExist(id))
                {
                    Customer customer = _context.Customers.Where(c => c.Id == id).First();
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Success"
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Not Found"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }

        public ResultDto Edit(EditCustomerDto req)
        {
            try
            {
                if (IsExist(req.Id))
                {
                    Customer customer = _context.Customers.Where(c => c.Id == req.Id).First();

                    customer.FirstName = req.FirstName;
                    customer.LastName = req.LastName;
                    customer.Email = req.Email;
                    customer.DateOfBirth = req.DateOfBirth;
                    customer.BankAccountNumber = req.BankAccountNumber;
                    customer.PhoneNumber = req.PhoneNumber;
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Success"
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Not Found"
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }

        public ResultDto<List<Customer>> Get()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                customers = _context.Customers.ToList();
                if (customers.Count() != 0)
                {
                    return new ResultDto<List<Customer>>
                    {
                        IsSuccess = true,
                        Message = "Success",
                        Data = customers
                    };
                }
                else
                {
                    return new ResultDto<List<Customer>>
                    {
                        IsSuccess = false,
                        Message = "Not Found",
                        Data = customers
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDto<List<Customer>>
                {
                    IsSuccess = false,
                    Message = e.Message,
                    Data = customers
                };
            }
        }

        public ResultDto<Customer> GetById(int id)
        {
            Customer customer = new Customer();
            try
            {
                if (IsExist(id))
                {
                    customer = _context.Customers.Where(c => c.Id == id).First();
                    
                    return new ResultDto<Customer>
                    {
                        IsSuccess = true,
                        Message = "Success",
                        Data = customer
                    };
                }
                else
                {
                    return new ResultDto<Customer>
                    {
                        IsSuccess = false,
                        Message = "Not Found",
                        Data = customer
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDto<Customer>
                {
                    IsSuccess = false,
                    Message = e.Message,
                    Data = customer
                };
            }
        }

        public bool IsExist(int id)
        {
            try
            {
                if (_context.Customers.Any(c=>c.Id == id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
    public class AddCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }

    public class EditCustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}

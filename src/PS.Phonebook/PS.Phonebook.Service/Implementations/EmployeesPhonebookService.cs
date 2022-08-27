using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using PS.Phonebook.Domain.Enums;
using PS.Phonebook.Domain.Response;
using PS.Phonebook.Domain.ViewModels;
using PS.Phonebook.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PS.Phonebook.Service.Implementations
{
    public class EmployeesPhonebookService : IEmployeesPhonebookService
    {

        private readonly IEmployeesPhonebook _dbRepository;

        public EmployeesPhonebookService(IEmployeesPhonebook dbRepository)
        {
            _dbRepository = dbRepository;
        }




        public async Task<IBaseResponse<EmployeesPhonebook>> GetEmployeePhonebookAsync(int id)
        {

            var baseResponse = new BaseResponse<EmployeesPhonebook>();

            try
            {
                var item = await _dbRepository.GetAsync(id);

                if (item == null)
                {
                    baseResponse.Description = "EmployeePhonebook not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = item;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeesPhonebook>()
                {
                    Description = $"[GetEmployeePhonebookAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }


        public async Task<IBaseResponse<IEnumerable<EmployeesPhonebook>>> GetAllEmployeesPhonebooksAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<EmployeesPhonebook>>();

            try
            {
                var items =  await _dbRepository.GetAll().ToListAsync();

                if (items == null)
                {
                    baseResponse.Description = "GetAllEmployeesPhonebooksAsync not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = items;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<IEnumerable<EmployeesPhonebook>>()
                {
                    Description = $"[GetAllEmployeesPhonebooksAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

       
        public async Task<IBaseResponse<EmployeesPhonebook>> CreateEmployeesPhonebookAsync(EmployeesPhonebookViewModel model)
        {
            var baseResponse = new BaseResponse<EmployeesPhonebook>();

            try
            {

                var employeesPhonebook = CreateNewEmployeesPhonebook(model);

                if (employeesPhonebook == null)
                {
                    baseResponse.Description = "employeesPhonebook equals null";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }


                var item = await _dbRepository.CreateAsync(employeesPhonebook);

                if (item == null)
                {
                    baseResponse.Description = "EmployeePhonebook not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = item;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeesPhonebook>()
                {
                    Description = $"[CreateEmployeesPhonebookAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }




        public async Task<IBaseResponse<EmployeesPhonebook>> UpdateEmployeesPhonebookAsync(EmployeesPhonebookViewModel model)
        {
            var baseResponse = new BaseResponse<EmployeesPhonebook>();

            try
            {
                var item = await _dbRepository.GetAsync(model.Id);

                if (item == null)
                {
                    baseResponse.Description = "EmployeePhonebook not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                await _dbRepository.UpdateAsync(item);

                baseResponse.Data = item;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeesPhonebook>()
                {
                    Description = $"[UpdateEmployeesPhonebookAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<EmployeesPhonebook>> DeleteEmployeesPhonebookAsync(EmployeesPhonebookViewModel model)
        {
            var baseResponse = new BaseResponse<EmployeesPhonebook>();

            try
            {
                var item = await _dbRepository.GetAsync(model.Id);

                if (item == null)
                {
                    baseResponse.Description = "EmployeePhonebook not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }

                await _dbRepository.DeletAsync(item);

                baseResponse.Data = item;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;

            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeesPhonebook>()
                {
                    Description = $"[DeleteEmployeesPhonebookAsync] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }





        #region HelperMethods

        private EmployeesPhonebook CreateNewEmployeesPhonebook(EmployeesPhonebookViewModel model)
        {

            var position = new Position()
            {
                Name = model.Position
            };
            var subdivision = new Subdivision()
            {
                Name = model.Subdivision
            };
            var department = new Department()
            {
                Name = model.Department
            };

            var organization1 = new Organization1()
            {
                Name = model.Organization1
            };
            var organization2 = new Organization2()
            {
                Name = model.Organization2
            };
            var organization3 = new Organization3()
            {
                Name = model.Organization3
            };


            var organization = new Organization()
            {
                Name = model.OrganizationName,
                Organization1 = organization1,
                Organization2 = organization2,
                Organization3 = organization3,
                Address = model.Address,
                Email = model.Email,
                Site = model.Site,
                Department = department,
                Subdivision = subdivision,
                Fax1 = model.Fax1,
                Fax2 = model.Fax2,
                CodeAMTC = model.CodeAMTC,
                FramePhoneCode = model.FramePhoneCode,
                FramePhone = model.FramePhone,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Phone3 = model.Phone3
            };

            var employee = new Employee()
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                SellularPhone1 = model.SellularPhone1,
                SellularPhone2 = model.SellularPhone2,
                Position = position,
                Organization = organization
            };


            var employeesPhonebook = new EmployeesPhonebook()
            {
                Index = model.Index,
                Employee = employee,
            };

            return employeesPhonebook;
        }

        #endregion




    }
}

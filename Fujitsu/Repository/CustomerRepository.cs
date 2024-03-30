
using Fujitsu.Data;
using Fujitsu.Models;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace Fujitsu.Repository
{
    public class CustomerRepository
    {
        private readonly TestFidContext db;


        public CustomerRepository()
        {
            this.db = new TestFidContext();
        }

        public async Task<BaseModelResponse<CustomerModel>> GetCustomer(BaseModelResponse<CustomerModel> model)
        {
            try
            {
                if (model == null || model.Data == null)
                {
                    return new BaseModelResponse<CustomerModel>
                    {
                        isError = true,
                        isMessage = "Invalid input model"
                    };
                }

                var data = await Suppliers();

                data = FilterData(data, model.Data);

                if (data.Count != 0)
                {
                    // Data exists
                    model.DataList = data.Select(item => new CustomerModel
                    {
                        supplierCode = item.SupplierCode,
                        supplierName = item.SupplierName,
                        city = item.City,
                        province = item.Province,
                        Address = item.Address,
                        pic = item.Pic,
                    }).ToList();

                    model.isError = false;
                    model.isMessage = "Data Retrieved";
                }
                else
                {
                    model.isError = true;
                    model.isMessage = "Data Not Found";
                }

                return model;
            }
            catch (Exception ex)
            {
                return new BaseModelResponse<CustomerModel>
                {
                    isError = true,
                    isMessage = ex.Message
                };
            }
        }
        public async Task<BaseModelResponse<CustomerModel>> InsertNewCustomer(BaseModelResponse<CustomerModel> model)
        {
            try
            {
                if (model == null)
                {
                    model.isError = true;
                    model.isMessage = "Invalid input model";

                    return model;

                }

                var checkCode = await isUniqueCustomerCode(model.Data.supplierCode);
                if (checkCode.Contains("Error"))
                {
                    model.isError = true;
                    model.isMessage = checkCode;
                }
                else
                {
                    await insert(model.Data);
                    model.isError = false;
                    model.isMessage = "Insert Succes";
                }
                return model;
            }
            catch (Exception ex)
            {
                model.isError = true;
                model.isMessage = ex.Message;
                return model;

            }
        }
        public async Task<BaseModelResponse<CustomerModel>> UpdateExistingCustomer(BaseModelResponse<CustomerModel> model)
        {
            try
            {
                if (model == null)
                {
                    model.isError = true;
                    model.isMessage = "Invalid input model";

                    return model;

                }

                var checkCode = await isExistingCustomerCode(model.Data.supplierCode);
                if (!checkCode)
                {
                    model.isError = true;
                    model.isMessage = "Something went wrong";
                }
                else
                {
                    await Update(model.Data);
                    model.isError = false;
                    model.isMessage = "Update Succes";
                }
                return model;
            }
            catch (Exception ex)
            {
                model.isError = true;
                model.isMessage = ex.Message;
                return model;

            }
        }
        public async Task<BaseModelResponse> DeleteCustomer(BaseModelResponse model)
        {
            try
            {
                if (model == null)
                {
                    
                    model.isError  = true;
                    model.isMessege = "Invalid input model";

                    return model;

                }

                var checkCode = await isExistingCustomerCode(model.code);
                if (!checkCode)
                {
                    model.isError = true;
                    model.isMessege = "Something went wrong";
                }
                else
                {
                    await Delete(model.code);
                    model.isError = false;
                    model.isMessege = "Delete Succes";
                }
                return model;
            }
            catch (Exception ex)
            {
                model.isError = true;
                model.isMessege = ex.Message;
                return model;

            }
        }
        public List<CustomerModel> ReadExcel(string filePath)
        {
            var excelData = new List<CustomerModel>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    var dataTable = result.Tables[0];

                    if (dataTable.Columns.Contains("supplierCode") &&
                        dataTable.Columns.Contains("supplierName") &&
                        dataTable.Columns.Contains("address") &&
                        dataTable.Columns.Contains("province") &&
                        dataTable.Columns.Contains("city") &&
                        dataTable.Columns.Contains("pic"))
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var dataModel = new CustomerModel
                            {
                                supplierCode = row["supplierCode"].ToString(),
                                supplierName = row["supplierName"].ToString(),
                                Address = row["address"].ToString(),
                                province = row["province"].ToString(),
                                city = row["city"].ToString(),
                                pic = row["pic"].ToString(),
                            };

                            excelData.Add(dataModel);
                        }
                    }
                    else
                    {
                        Console.WriteLine("One or more columns are missing in the Excel file.");
                    }
                }
            }

            return excelData;
        }

        public async Task SubmitDataIntoDatabase(List<CustomerModel> excelData)
        {
            foreach (var dataModel in excelData)
            {
                var checkCode = await isExistingCustomerCode(dataModel.supplierCode);
                if (!checkCode)
                {
                    //if suplierCode didm't exsist then add new
                    await insert(dataModel);
                }
                else
                {
                    await Update(dataModel);
                    //if suplierCode did exsist then update
                }
            }

            db.SaveChanges();
        }


        private async Task Delete(string supplierCode)
        {
            var dataSup = await db.TbMSuppliers.Where(x => x.SupplierCode == supplierCode).FirstOrDefaultAsync();

            if (dataSup != null)
            {
                db.TbMSuppliers.Remove(dataSup);
                await db.SaveChangesAsync();
            }
        }
        private async Task Update (CustomerModel Data)
        {
            var dataSup = await db.TbMSuppliers.Where(x=>x.SupplierCode == Data.supplierCode).FirstOrDefaultAsync();

            if (dataSup != null)
            {
                dataSup.SupplierName = Data.supplierName;
                dataSup.Address = Data.Address;
                dataSup.Province = Data.province; 
                dataSup.City = Data.city;
                dataSup.Pic = Data.pic;
            }

            db.TbMSuppliers.Update(dataSup);
            await db.SaveChangesAsync();
        }
        private async Task insert(CustomerModel Data)
        {
            TbMSupplier Obj = new TbMSupplier()
            {
                SupplierCode = Data.supplierCode,
                SupplierName = Data.supplierName,
                Address = Data.Address,
                Province = Data.province,
                City = Data.city,
                Pic = Data.pic
            };

            db.TbMSuppliers.Add(Obj);
            await db.SaveChangesAsync();
        }
        private async Task<bool> isExistingCustomerCode(string code)
        {
            var check = await db.TbMSuppliers.Where(x => x.SupplierCode == code).FirstOrDefaultAsync();
            if (check != null)
                return true;

            return false;
        }
        private async Task<string> isUniqueCustomerCode(string code)
        {
            var check = await db.TbMSuppliers.Where(x => x.SupplierCode == code).FirstOrDefaultAsync();
            if (check != null)
                return "Error : Supplier Code already exist";

            return "Ok";
        }
        private List<TbMSupplier> FilterData(List<TbMSupplier> data, CustomerModel filters)
        {
            var filteredData = data;

            if (!string.IsNullOrEmpty(filters.supplierCode))
            {
                filteredData = filteredData.Where(x => x.SupplierCode.ToLower().StartsWith(filters.supplierCode.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(filters.province))
            {
                filteredData = filteredData.Where(x => x.Province.ToLower() == filters.province.ToLower()).ToList();
            }

            if (!string.IsNullOrEmpty(filters.city))
            {
                filteredData = filteredData.Where(x => x.City.ToLower() == filters.city.ToLower()).ToList();
            }

            return filteredData;
        }
        private async Task<List<TbMSupplier>> Suppliers()
        {
            return await db.TbMSuppliers.ToListAsync();
        }
    }
}

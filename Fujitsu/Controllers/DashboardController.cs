using Azure;
using Fujitsu.Lov;
using Fujitsu.Models;
using Fujitsu.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace NC8Test.Controllers
{
	public class DashboardController : Controller
	{
		CustomerRepository CustRepo = new CustomerRepository();
		CustomerLov lov = new CustomerLov();


		public IActionResult DashboardIndex()
		{
			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> generateTable(CustomerModel request)
		{
			BaseModelResponse<CustomerModel> model = new BaseModelResponse<CustomerModel>();
			model.Data = request;
			var response = await CustRepo.GetCustomer(model);

			return Json(response);
		}

        [HttpPost]
        public async Task<IActionResult> Insert(CustomerModel request)
        {
            BaseModelResponse<CustomerModel> model = new BaseModelResponse<CustomerModel>();
			model.Data = request;
            
            var response = await CustRepo.InsertNewCustomer(model);

            return Json(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerModel request)
        {
            BaseModelResponse<CustomerModel> model = new BaseModelResponse<CustomerModel>();
            model.Data = request;

            var response = await CustRepo.UpdateExistingCustomer(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string supplierCode)
        {
            BaseModelResponse model = new BaseModelResponse();
            model.code = supplierCode;

            var response = await CustRepo.DeleteCustomer(model);

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            BaseModelResponse response = new BaseModelResponse();
            try
            {
                var file = Request.Form.Files[0];

                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var excelData = CustRepo.ReadExcel(filePath);

                await CustRepo.SubmitDataIntoDatabase(excelData);
                response.isError = false;
                response.isMessege = "File uploaded and data inserted successfully";
                return Json(response);
            }
            catch (Exception ex)
            {
                response.isError = false;
                response.isMessege = "Error uploading file: " + ex.Message;
                return Json(response);
            }
        }


        

        public IActionResult populateDdProv()
		{
			List<DropdownModel> response = new List<DropdownModel>();

			response =  lov.DropdownProv(response);

			return Json(response);
		}

        public IActionResult populateDdCity(string prov)
        {
            List<DropdownModel> response = new List<DropdownModel>();
            response = lov.DropdownCity(prov);

            return Json(response);
        }
    }
}

using System;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.DataAccess;
using Marqueone.TimeAndMaterials.Api.DataAccess.Services;
using Marqueone.TimeAndMaterials.Api.Models;
using Marqueone.TimeAndMaterials.Api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marqueone.TimeAndMaterials.Api.Controllers
{

    [Route("_api/[controller]")]
    [Produces("application/json")]
    public class ContactsController : Controller
    {
        private TamContext _context { get; }
        private ILogger<ContactsController> _logger;

        private AddressService _addressService { get; set; }
        private ContactService _contactsService { get; set; }

        public ContactsController(ILogger<ContactsController> logger,
                                  TamContext context,
                                  AddressService addressService,
                                  ContactService contactService)
        {
            _context = context;
            _logger = logger;
            _addressService = addressService;
            _contactsService = contactService;
        }

        #region addresses
        [HttpGet]
        [Route("addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                return Ok(await _addressService.GetAddresses());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("address/by-id/{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                return Ok(await _addressService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

        [HttpGet]
        [Route("address/by-type/{type}")]
        public async Task<IActionResult> GetByAddressType(AddressType type)
        {
            try
            {
                return Ok(await _addressService.GetByType(type));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("address/add")]
        public async Task<IActionResult> Add([FromBody]NewAddressViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _addressService.Add(addressLine1: model.AddressLine1,
                                                addressLine2: model.AddressLine2,
                                                addressLine3: model.AddressLine3,
                                                city: model.City,
                                                province: model.Province,
                                                postalCode: model.PostalCode,
                                                gmt: model.GMT,
                                                addressType: model.AddressType);

                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to add new Address", Status = 400 });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("address/update")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(400, ModelState);
                }

                var result = await _addressService.Update(id: model.Id,
                                                    addressLine1: model.AddressLine1,
                                                    addressLine2: model.AddressLine2,
                                                    addressLine3: model.AddressLine3,
                                                    city: model.City,
                                                    province: model.Province,
                                                    postalCode: model.PostalCode,
                                                    gmt: model.GMT,
                                                    addressType: model.AddressType);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to update ADdress", Status = 400 });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("address/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return StatusCode(400, new { Message = $"Invalid id provided", Status = 400 });
                }

                var result = await _addressService.Delete(id: id);
                if (!result)
                {
                    return StatusCode(400, new { Message = $"Unable to delete Address with id: {id}", Status = 400 });
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

        #endregion

        #region contacts

        /*[HttpGet]
        [Route("contacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                return Ok(await _contactsService.GetContacts());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("contact/by-id/{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                return Ok(await _addressService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500, new { Message = ex.Message, Status = 500 });
            }
        }

        [HttpGet]
        [Route("contact/by-type/{type}")]
        public async Task<IActionResult> GetByAddressType(AddressType type)
        {
            try
            {
                return Ok(await _addressService.GetByType(type));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(500);
            }
        }*/

        #endregion

    }
}
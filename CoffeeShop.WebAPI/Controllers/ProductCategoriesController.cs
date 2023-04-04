﻿using CoffeeShop.BLL.Services.Inerfaces;
using CoffeeShop.DAL.DBModel;
using CoffeeShop.DAL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IGenericService<ProductCategoryDto, ProductCategory> _service;

        public ProductCategoriesController(IGenericService<ProductCategoryDto, ProductCategory> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetList()
        {
            var response = await _service.GetListAsync();
            return response;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCategoryDto>> GetByIdAsync(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _service.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryDto>> Create(ProductCategoryDto itemDto)
        {

            var response = await _service.AddAsync(itemDto);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ProductCategoryDto> Update(int id, [FromBody] ProductCategoryDto obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _service.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }
            response = _service.Update(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _service.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}

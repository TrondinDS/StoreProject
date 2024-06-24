﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreProject.DB.DTO.User;
using StoreProject.DB.Models;
using StoreProject.Services.Interfaces;

namespace StoreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUser()
        { 
            var users = await userService.GetAllAsync();
            var customerDTOs = mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(customerDTOs);
        }

        /// <summary>
        /// Получение клиента по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        { 
            var user = await userService.GetByIdAsync(id);
            if (user == null) 
            {
                return NotFound();
            }
            var userDTO = mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            await userService.AddAsync(user);
            var userResultDTO = mapper.Map<UserDTO> (user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userResultDTO);
        }

        /// <summary>
        /// Обновление клиента
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, UserDTO userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            var existingUser = await userService.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var user = mapper.Map<User>(userDto);
            await userService.UpdateAsync(user);
            return Ok(user);
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await userService.DeleteAsync(id);
            return NoContent();
        }
    }
}

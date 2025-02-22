﻿using AutoMapper;
using SGT.Application.Interfaces;
using SGT.Domain.Entities;
using SGT.Infrastructure.Persistence.Interfaces;
using SGT.Application.Dtos.Request;
using SGT.Application.Dtos.Response;
using FluentValidation;
using SGT.Application.Validators;
using System.Runtime.CompilerServices;

namespace SGT.Application.Services
{
    public class ApplicationUserService : IApplicationUserApplication
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationUserRequestDtoValidator _applicationUserRequestDtoValidationRules;

        public ApplicationUserService(IApplicationUserRepository userRepository, IMapper mapper, ApplicationUserRequestDtoValidator applicationUserRequestDtoValidationRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _applicationUserRequestDtoValidationRules = applicationUserRequestDtoValidationRules;
        }

        #region

        public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
        {

            var usersEntity = await _userRepository.GetUsersAsync();

            return _mapper.Map<IEnumerable<UserResponseDto>>(usersEntity);
        }

        public async Task<UserResponseDto?> GetUserByEmailAsync(string email)
        {
            var userEntity = await _userRepository.GetUserByEmailAsync(email);

            return _mapper.Map<UserResponseDto>(userEntity);
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(string userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);

            return _mapper.Map<UserResponseDto>(userEntity);
        }

        public async Task<bool> CreateUserAsync(CreateApplicationUserRequestDto user)
        {
     
            var validationResult = await _applicationUserRequestDtoValidationRules.ValidateAsync(user);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                                             .Select(error => new Exceptions.ErrorValidation(error.PropertyName, error.ErrorMessage))
                                             .ToList();

                throw new Exceptions.ValidationException(errors);
            }

            var userEnity = _mapper.Map<ApplicationUser>(user);

            return await _userRepository.CreateUserAsync(userEnity, user.Password!);
        }

        public async Task<bool> UpdateUserAsync(UpdateApplicationUserRequestDto user)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(user.Id!);

            userEntity = _mapper.Map(user, userEntity);

            return await _userRepository.UpdateUserAsync(userEntity!);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }

        #endregion

        #region Roles

        public async Task<IList<string>> GetRolesAsync(string userId)
        {
            return await _userRepository.GetRolesAsync(userId);
        }

        public async Task<bool> AddToRoleAsync(string userId, string roleName)
        {
            return await _userRepository.AddToRoleAsync(userId, roleName);
        }

        public Task<bool> AddToRolesAsync(string userId, IEnumerable<string> roleNames)
        {
            return _userRepository.AddToRolesAsync(userId, roleNames);
        }

        public async Task<bool> RemoveFromRoleAsync(string userId, string roleName)
        {
            return await _userRepository.RemoveFromRoleAsync(userId, roleName);
        }

        public async Task<bool> RemoveFromRolesAsync(string userId, IEnumerable<string> roleNames)
        {
            return await _userRepository.RemoveFromRolesAsync(userId, roleNames);
        }

        #endregion
    }
}

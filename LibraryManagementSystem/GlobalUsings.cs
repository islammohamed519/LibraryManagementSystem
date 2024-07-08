global using System.Reflection;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using FluentValidation;
global using AutoMapper;

global using LibraryManagementSystem.Core.Consts;
global using LibraryManagementSystem.Core.Entities;
global using LibraryManagementSystem.Core.Entities.Common;
global using LibraryManagementSystem.Persistence;
global using LibraryManagementSystem.Persistence.Repositories.Interfaces;
global using LibraryManagementSystem.Persistence.Repositories;
global using LibraryManagementSystem.Contracts.Books;
global using LibraryManagementSystem.Contracts.Categories;
global using LibraryManagementSystem.RequestHelpers;
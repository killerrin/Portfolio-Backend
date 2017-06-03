﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models;
using Portfolio.API.Repositories;
using Portfolio.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IRepository<PortfolioItem> _portfolioItemRepository;
        private readonly IRepository<PortfolioItemLink> _portfolioItemLinkRepository;
        private readonly AuthenticationService _authenticationService;

        public AdminController(IRepository<PortfolioItem> portfolioItemRepository, IRepository<PortfolioItemLink> portfolioItemLinkRepository)
        {
            _portfolioItemRepository = portfolioItemRepository;
            _portfolioItemLinkRepository = portfolioItemLinkRepository;
            _authenticationService = new AuthenticationService(new UserRepository(portfolioItemRepository.DatabaseInfo.Context));
        }
    }
}
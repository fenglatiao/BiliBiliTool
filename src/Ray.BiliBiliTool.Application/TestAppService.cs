﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos;
using Ray.BiliBiliTool.Application.Attributes;
using Ray.BiliBiliTool.Application.Contracts;
using Ray.BiliBiliTool.Config.Options;
using Ray.BiliBiliTool.DomainService.Interfaces;
using Ray.BiliBiliTool.Infrastructure.Enums;

namespace Ray.BiliBiliTool.Application
{
    public class TestAppService : AppService, ITestAppService
    {
        private readonly ILogger<LiveLotteryTaskAppService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAccountDomainService _accountDomainService;

        public TestAppService(
            IConfiguration configuration,
            ILogger<LiveLotteryTaskAppService> logger,
            IAccountDomainService accountDomainService
            )
        {
            _configuration = configuration;
            _logger = logger;
            _accountDomainService = accountDomainService;
        }

        public override string TaskName => "Test";


        [TaskInterceptor("测试Cookie", TaskLevel.One)]
        public override void DoTask()
        {
            _accountDomainService.LoginByCookie();
        }
    }
}

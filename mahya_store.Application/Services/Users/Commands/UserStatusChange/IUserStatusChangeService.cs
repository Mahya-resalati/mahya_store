﻿using mahya_store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahya_store.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long UserId);
    }
}
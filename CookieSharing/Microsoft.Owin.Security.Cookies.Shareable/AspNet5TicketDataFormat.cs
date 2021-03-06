// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataProtection;

namespace Microsoft.Owin.Security.Cookies.Shareable
{
    public class AspNet5TicketDataFormat : SecureDataFormat<AuthenticationTicket>
    {
        public AspNet5TicketDataFormat(IDataProtector protector, string authenticationType)
            : base(new AspNet5TicketSerializer(authenticationType), protector, TextEncodings.Base64Url)
        {
        }
    }
}

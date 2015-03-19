// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;

namespace Microsoft.AspNet.Builder
{
    public static class CookieAppBuilderExtensions
    {
        public static IApplicationBuilder UseCookieAuthentication(
            [NotNull] this IApplicationBuilder app,
            Action<CookieAuthenticationOptions> configureOptions = null,
            string optionsName = "",
            DataProtectionProvider dataProtectionProvider = null)
        {
            if (dataProtectionProvider != null)
            {
                return app.UseMiddleware<ShareableCookieAuthenticationMiddleware>(
                    dataProtectionProvider,
                    new ConfigureOptions<CookieAuthenticationOptions>(configureOptions ?? (o => { }))
                    {
                        Name = optionsName
                    });
            }
            else
            {
                return app.UseCookieAuthentication(configureOptions, optionsName);
            }
        }

        private sealed class ShareableCookieAuthenticationMiddleware : CookieAuthenticationMiddleware
        {
            public ShareableCookieAuthenticationMiddleware(
                [NotNull] RequestDelegate next,
                [NotNull] ILoggerFactory loggerFactory,
                [NotNull] IOptions<CookieAuthenticationOptions> options,
                [NotNull] IDataProtectionProvider dataProtectionProvider,
                ConfigureOptions<CookieAuthenticationOptions> configureOptions)
                : base(next, dataProtectionProvider, loggerFactory, options, configureOptions)
            {
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace PocketGov.Tests
{
    public class AppInitializer
    {
        private static IApp _app;
        private static bool _isFirstRun = true;
        private static readonly string ApkPath = "../../../org.denvergov.pocketgov-Signed.apk";
        public static IApp StartApp(Platform platform)
        {
            AppDataMode dataMode;
            if (_isFirstRun)
            {
                dataMode = AppDataMode.Clear;
                _isFirstRun = false;
            }
            else
            {
                dataMode = AppDataMode.DoNotClear;
            }

            if (platform == Platform.Android)
            {

                _app = ConfigureApp
                    .Android
                    .ApkFile(ApkPath)
                    .StartApp(dataMode);
            }
            else
            {
                throw new NotImplementedException("iOS not configured yet");
                /*
                _app = ConfigureApp
                .iOS
                .AppBundle(AppPath)
                .StartApp();
                */
            }

            return _app;
        }
    }
}

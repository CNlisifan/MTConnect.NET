﻿// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace MTConnect.Client
{
    public delegate void MTConnectDevicesHandler(MTConnectDevices.Document document);

    public delegate void MTConnectStreamsHandler(MTConnectStreams.Document document);

    public delegate void MTConnectAssetsHandler(MTConnectAssets.Document document);

    public delegate void MTConnectErrorHandler(MTConnectError.Document errorDocument);

    public delegate void XmlHandler(string xml);

    public delegate void ConnectionErrorHandler(Exception ex);

    public delegate void StreamStatusHandler();
}
// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Driver;
// </using_directives>

// <client_credentials> 
// New instance of CosmosClient class
//var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));
var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));

var settings = client.Settings;

Console.WriteLine(settings.Server.Host);
// </client_credentials>

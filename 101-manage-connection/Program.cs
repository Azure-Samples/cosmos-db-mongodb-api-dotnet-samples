// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Bson;
using MongoDB.Driver;
// </using_directives>

// <client_credentials> 
// New instance of CosmosClient class
var client = new MongoClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));

var settings = client.Settings;

Console.WriteLine(settings.Server.Host);
// </client_credentials>

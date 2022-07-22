﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Bson;
using MongoDB.Driver;
// </using_directives>

// <create_databases>
var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));

client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertOne(new BsonDocument() { { "Name", "surfboard" } });
// </create_database>

// <get_database>
var collections = client.GetDatabase("adventureworks").ListCollectionNames();
Console.WriteLine($"The database has {collections.ToList().Count} collection.");
// </get_database>

// <database_exists>

// <get_all_databases>
var dbFindList = client.ListDatabaseNames().ToList();

var dbFound = dbFindList.FirstOrDefault(x => x == "adventureworks");
if (dbFound is not null)
{
    Console.WriteLine($"{dbFound} database found");
}
else
{
    Console.WriteLine($"{dbFound} database not found.");
}
// </get_all_databases>

// <drop_database>
client.DropDatabase("adventureworks");
// </drop_database>
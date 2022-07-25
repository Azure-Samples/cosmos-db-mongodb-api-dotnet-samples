// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Bson;
using MongoDB.Driver;
// </using_directives>

// <create_database>
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
// </get_all_databases>

// <check_database_exists>
var dbFound = dbFindList.FirstOrDefault(x => x == "adventureworks");
if (dbFound is not null)
{
    Console.WriteLine($"{dbFound} database found");
}
else
{
    Console.WriteLine($"{dbFound} database not found.");
}
// </check_database_exists>

// <drop_database>
client.DropDatabase("adventureworks");
// </drop_database>
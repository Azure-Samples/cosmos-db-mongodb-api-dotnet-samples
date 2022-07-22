// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Bson;
using MongoDB.Driver;
// </using_directives>

// <client_credentials> 
// New instance of CosmosClient class
//var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));
var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));

var settings = client.Settings;

Console.WriteLine(settings.Server.Host);
// </client_credentials>

// <create_collection>
// insert one document
var product = new BsonDocument
{
    { "name", "Sand Surfboard" },
    { "category", "gear-surf-surfboards" },
    { "count", 1 }
};

client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertOne(product);

// insert many documents
var products = new List<BsonDocument>() 
{
    new BsonDocument
    {
        { "name", "Sand Surfboard" },
        { "category", "gear-surf-surfboards" },
        { "count", 1 }
    },
    new BsonDocument
    {
        { "name", "Ocean Surfboard" },
        { "category", "gear-surf-surfboards" },
        { "count", 5 }
    }
};

client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertMany(products);
// </create_collection>

// <get_indexes>
var indexes = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").Indexes;

var count = 0;
using (var cursor = await indexes.ListAsync())
{
    do
    {
        if (cursor.Current != null)
        {
            foreach (var index in cursor.Current)
            {
                Console.WriteLine(cursor.Current);
                count++;
            }
        }
    }
    while (await cursor.MoveNextAsync());
}
// </get_indexes>


// <drop_collection>
client.GetDatabase("adventureworks").DropCollection("products");
// </drop_collection>
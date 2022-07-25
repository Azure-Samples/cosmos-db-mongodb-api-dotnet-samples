// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Libmongocrypt;
// </using_directives>

// <client_credentials> 
// New instance of CosmosClient class
//var client = new MongoClient();
var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));

var collection = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products");
// </client_credentials>

// <query_documents>
// insert documents to query
var products = new List<BsonDocument>()
{
    new BsonDocument
    {
        { "_id",  new ObjectId("62b1f43a9446918500c875c5") },
        { "name", "Sand Surfboard" },
        { "category", "gear-surfboards" },
        { "count", 1 }
    },
    new BsonDocument
    {
        { "_id",   new ObjectId("12b1f43a9446918500c875c5") },
        { "name", "Ocean Surfboard" },
        { "category", "gear-surfboards" },
        { "count", 5 }
    },
    new BsonDocument
    {
        { "_id",   new ObjectId("55b1f43a9446918500c875c5") },
        { "name", "Beach Towel" },
        { "category", "gear-accessories" },
        { "count", 4 }
    },
    new BsonDocument
    {
        { "_id",   new ObjectId("33b1f43a9446918500c875c5") },
        { "name", "Sunglasses" },
        { "category", "gear-accessories" },
        { "count", 5 }
    }
};


collection.InsertMany(products);

// Find by ID
var filter = Builders<BsonDocument>.Filter.Gt("_id", "62b1f43a9446918500c875c5");
var query1 = collection.Find<BsonDocument>(filter).FirstOrDefault();
Console.WriteLine($"Query by id: {query1["_id"]} \n");

// Find by doc property
var filter2 = Builders<BsonDocument>.Filter.Eq("name", "Sand Surfboard");
var query2 = collection.Find<BsonDocument>(filter2).FirstOrDefault();
Console.WriteLine($"Query by property: {query2["name"]} \n");

// Find all by property
var filter3 = Builders<BsonDocument>.Filter.Eq("category", "gear-surfboards");
var query3 = collection.Find<BsonDocument>(filter3);
Console.WriteLine("Query all by property:");
foreach (var item in query3.ToList())
{
    Console.WriteLine(item["name"]);
}

// Find all in a collection
var query4 = collection.Find<BsonDocument>(new BsonDocument()).ToList();
Console.WriteLine("\nQuery all in a collection:");
foreach (var item in query4.ToList())
{
    Console.WriteLine(item["name"]);
}

// Pagination - fine next 5 docs
// sort by name requires an index on name
var index = Builders<BsonDocument>.IndexKeys.Ascending("name");
collection.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(index));

var sort = Builders<BsonDocument>.Sort.Ascending("name");
var query5 = collection.Find<BsonDocument>(new BsonDocument()).Sort(sort).Skip(2).Limit(2).ToList();
Console.WriteLine("\nQuery using pagination:");
foreach (var item in query5.ToList())
{
    Console.WriteLine(item["name"]);
}
// </query_documents>
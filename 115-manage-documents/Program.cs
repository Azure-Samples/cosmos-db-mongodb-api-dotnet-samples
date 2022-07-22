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

var collection = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products");
// </client_credentials>

// <insert_document>
// insert one document
var product = new BsonDocument
{
    { "name", "Sand Surfboard" },
    { "category", "gear-surf-surfboards" },
    { "count", 1 }
};

collection.InsertOne(product);

// insert many documents
var products = new List<BsonDocument>() 
{
    new BsonDocument
    {
        { "name", "Lake Surfboard" },
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

collection.InsertMany(products);
// </insert_document>

// <update_document>
// update one item
var filter = Builders<BsonDocument>.Filter.Eq("name", "Sand Surfboard");
var update = Builders<BsonDocument>.Update.Set("name", "Sand Surfboard Pro");

collection.UpdateOne(filter, update);

//update many items
var filterMany = Builders<BsonDocument>.Filter.Eq("category", "gear-surf-surfboards");
var updateMany = Builders<BsonDocument>.Update.Set("category", "gear-surfboards");

collection.UpdateMany(filterMany, updateMany);
// </update_document>

// <bulk_write>
// perform multiple different types of operations
var models = new WriteModel<BsonDocument>[]
{
    new InsertOneModel<BsonDocument>(new BsonDocument(new BsonDocument
    {
        { "name", "Wave Paddleboard" },
        { "category", "gear-surfboards" },
        { "count", 1 }
    })),
    new UpdateOneModel<BsonDocument>(
        Builders<BsonDocument>.Filter.Eq("name", "Sand Surfboard Pro"),
        Builders<BsonDocument>.Update.Set("name", "Sand Surfboard Pro X")),
    new DeleteOneModel<BsonDocument>(new BsonDocument("name", "Ocean Surfboard"))
};

collection.BulkWrite(models);
// </bulk_write>

// <delete_document>
var deleteFilter = Builders<BsonDocument>.Filter.Eq("name", "Sand Surfboard Pro X");

collection.DeleteOne(deleteFilter);

// </delete_document>
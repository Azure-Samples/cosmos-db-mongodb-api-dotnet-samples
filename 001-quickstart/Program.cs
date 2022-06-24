// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Driver;
// </using_directives>

// <client_credentials> 
// New instance of CosmosClient class
var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_CONNECTION"));
// </client_credentials>

// <new_database> 
// Database reference with creation if it does not already exist
var db = client.GetDatabase("adventure");
// </new_database>

// <new_container> 
// Container reference with creation if it does not alredy exist
var _products = db.GetCollection<Product>("products");
// </new_container>

// <new_item> 
// Create new object and upsert (create or replace) to container
_products.InsertOne(new Product(
    Guid.NewGuid().ToString(),
    "gear-surf-surfboards",
    "Yamba Surfboard", 
    12, 
    false
));
// </new_item>

// <read_item> 
// Read item from container
var product = _products.Find(p => p.Name.Contains("Yamba")).FirstOrDefault();
// </read_item>

// <query_items> 
// Create query using a SQL string and parameters

// </query_items>
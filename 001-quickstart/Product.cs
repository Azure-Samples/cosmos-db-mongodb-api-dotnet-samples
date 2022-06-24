// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <entity>
// C# record representing an item in the container
public record Product(
    string Id,
    string Category,
    string Name,
    int Quantity,
    bool Sale
);
// </entity>
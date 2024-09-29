using System;
using System.Collections.Generic;

namespace ST.Doamin.Commons.Primitives;

/// <summary>
/// Represents a response object.
/// </summary>
public class Response
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Response"/> class.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the response is a success or failure.</param>
    /// <param name="message">The message associated with the response.</param>
    protected Response(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    /// <summary>
    /// Gets a value indicating whether the response is a success.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the response is a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the message associated with the response.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Creates a success response with the specified message.
    /// </summary>
    /// <param name="message">The success message.</param>
    /// <returns>A success response.</returns>
    public static Response Success(string message) => new Response(true, message);

    /// <summary>
    /// Creates a failure response with the specified message.
    /// </summary>
    /// <param name="message">The failure message.</param>
    /// <returns>A failure response.</returns>
    public static Response Failure(string message) => new Response(false, message);

    /// <summary>
    /// Creates a success response for a successful entity creation.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <returns>A success response for entity creation.</returns>
    public static Response CreateSuccessfully(string entityName) =>
           Success($"{entityName} has been added successfully.");

    /// <summary>
    /// Creates a success response for a successful entity update.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <returns>A success response for entity update.</returns>
    public static Response UpdateSuccessfully(string entityName) =>
        Success($"{entityName} has been edited successfully.");

    /// <summary>
    /// Creates a success response for a successful entity deletion.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <returns>A success response for entity deletion.</returns>
    public static Response DeleteSuccessfully(string entityName) =>
        Success($"{entityName} has been deleted successfully.");

    /// <summary>
    /// Creates a failure response for an entity not found.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A failure response for entity not found.</returns>
    public static Response NotFound(string entityName, Guid id) =>
        Failure($"{entityName} was not found with Id {id}");

    /// <summary>
    /// Creates a failure response for a failed entity update.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <returns>A failure response for entity update failure.</returns>
    public static Response UpdateFailed(string entityName) =>
        Failure($"Failed to update {entityName}.");

    /// <summary>
    /// Creates a failure response for a failed entity deletion.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <returns>A failure response for entity deletion failure.</returns>
    public static Response DeleteFailed(string entityName) =>
        Failure($"Failed to delete {entityName}.");

    /// <summary>
    /// Creates a failure response for a failed entity creation.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <returns>A failure response for entity creation failure.</returns>
    public static Response CreateFailed(string entityName) =>
        Failure($"Failed to create {entityName}.");
}

/// <summary>
/// Represents a response object with data.
/// </summary>
/// <typeparam name="T">The type of the data.</typeparam>
public class Response<T> : Response
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class.
    /// </summary>
    /// <param name="data">The data associated with the response.</param>
    /// <param name="isSuccess">Indicates whether the response is a success or failure.</param>
    /// <param name="message">The message associated with the response.</param>
    protected Response(bool isSuccess, string message, T data) : base(isSuccess, message)
    {
        Data = data;
    }

    /// <summary>
    /// Gets the data associated with the response.
    /// </summary>
    public T Data { get; }

    /// <summary>
    /// Creates a success response with the specified data and message.
    /// </summary>
    /// <param name="data">The data associated with the response.</param>
    /// <param name="message">The success message.</param>
    /// <returns>A success response with data.</returns>
    public static Response<T> Success(string message, T data) => new Response<T>(true, message, data);

    /// <summary>
    /// Creates a failure response with the specified message.
    /// </summary>
    /// <param name="message">The failure message.</param>
    /// <returns>A failure response with data.</returns>
    public static Response<T> Failure(string message) => new Response<T>(false, message, default);

    /// <summary>
    /// Creates a failure response for an entity not found.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A failure response for entity not found.</returns>
    public static Response<T> NotFound(string entityName, Guid id) =>
        Failure($"{entityName} was not found with Id {id}");

    /// <summary>
    /// Creates a failure response for an entity not found by username.
    /// </summary>
    /// <param name="username">The username of the entity.</param>
    /// <returns>A failure response for entity not found.</returns>
    public static Response<T> NotFoundUserName(string username) =>
        Failure($"User was not found with Username {username}");
}
/// <summary>
/// Represents a paged response object with data.
/// </summary>
/// <typeparam name="T">The type of the data.</typeparam>
public class PagedResponse<T> : Response<List<T>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResponse{T}"/> class.
    /// </summary>
    /// <param name="items">The items for the current page.</param>
    /// <param name="totalCount">The total count of items across all pages.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    public PagedResponse(List<T> items, int totalCount, int pageNumber, int pageSize)
        : base(true, "Data retrieved successfully", items)
    {
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
    }

    /// <summary>
    /// Gets the total count of items across all pages.
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// Gets the current page number.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    /// Gets the number of items per page.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages { get; }
}

namespace TaskManagementDemo.Domain.Exceptions;

public class NotFoundException(string? resourceType, string? resourceIdentifier) : 
    Exception($"Resource of type {resourceType} with identifier {resourceIdentifier} was not found.")
{
}
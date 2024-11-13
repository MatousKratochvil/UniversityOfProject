using Core.ValueObjects.Simple.Abstract;

namespace Core.ValueObjects.Simple;

public record struct Son : IPersonRelationship;

public record struct Daughter : IPersonRelationship;

public record struct Father : IPersonRelationship;

public record struct Mother : IPersonRelationship;

public record struct Brother : IPersonRelationship;

public record struct Sister : IPersonRelationship;

public record struct Grandfather : IPersonRelationship;

public record struct Grandmother : IPersonRelationship;
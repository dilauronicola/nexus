using FluentAssertions;
using Nexus.Domain.Common;
using Nexus.Domain.Shared.ValueObjects.Identity;
using Xunit;

namespace Nexus.Domain.Tests.ValueObjects.Identity;

public class EmailTests
{
    [Fact]
    public void Should_Create_Valid_Email()
    {
        var email = new Email("info@nexusplatform.it");

        email.Value.Should().Be("info@nexusplatform.it");
    }

    [Fact]
    public void Should_Throw_When_Email_Is_Empty()
    {
        var action = () => new Email("");

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Should_Throw_When_Email_Is_Invalid()
    {
        var action = () => new Email("pippo");

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Should_Be_Equal_Ignoring_Case()
    {
        var first = new Email("INFO@nexusplatform.it");
        var second = new Email("info@nexusplatform.it");

        first.Should().Be(second);
    }
}
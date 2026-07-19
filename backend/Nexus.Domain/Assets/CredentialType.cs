namespace Nexus.Domain.Assets;

public enum CredentialType
{
    Web = 1,
    SSH = 2,
    Telnet = 3,
    Console = 4,
    Rdp = 5,
    Vnc = 6,
    Sftp = 7,
    Api = 8,
    Database = 9,
    Other = 99
}
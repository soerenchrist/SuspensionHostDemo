using System.Runtime.Serialization;

namespace SuspensionHostDemo.Presentation.State;

[DataContract]
public class MainState
{
    [DataMember]
    public string FirstName { get; set; } = string.Empty;

    [DataMember]
    public string LastName { get; set; } = string.Empty;
}
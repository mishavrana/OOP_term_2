using Microsoft.VisualBasic;

namespace Task_2;

public interface IPublisher
{
    void Subscribe(DateTimeDelegate dateTimeHandler);
}
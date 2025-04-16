using TFLaComp_1.DTO;

namespace TFLaComp_1.RegExParser
{
    public interface ICardParser
    {
        List<CardDTO> Parse(string input);
    }
}
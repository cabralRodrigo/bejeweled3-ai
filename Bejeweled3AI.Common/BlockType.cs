using System;

namespace Bejeweled3AI.Common
{
    [Flags]
    public enum BlockType
    {
        Amarelo,
        Azul,
        Branco,
        Laranja,
        Verde,
        Vermelho,
        Violeta,

        BombaAmarelo,
        BombaAzul,
        BombaBranco,
        BombaLaranja,
        BombaVerde,
        BombaVermelho,
        BombaVioleta,

        MisselAmarelo,
        MisselAzul,
        MisselBranco,
        MisselLaranja,
        MisselVerde,
        MisselVermelho,
        MisselVioleta,

        Matrix,
        Desconhecido
    }
}
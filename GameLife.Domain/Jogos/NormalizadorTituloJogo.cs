using System.Globalization;
using System.Text;

namespace GameLife.Domain.Jogos;

public static class NormalizadorTituloJogo
{
    public static string Normalizar(string titulo)
    {
        ArgumentNullException.ThrowIfNull(titulo);

        var tituloDecomposto = titulo.Normalize(NormalizationForm.FormD);
        var tituloNormalizado = new StringBuilder(tituloDecomposto.Length);
        var ultimoCaractereFoiEspaco = true;

        foreach (var caractere in tituloDecomposto)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(caractere) == UnicodeCategory.NonSpacingMark)
            {
                continue;
            }

            if (char.IsLetterOrDigit(caractere))
            {
                tituloNormalizado.Append(char.ToLowerInvariant(caractere));
                ultimoCaractereFoiEspaco = false;
                continue;
            }

            if (!ultimoCaractereFoiEspaco)
            {
                tituloNormalizado.Append(' ');
                ultimoCaractereFoiEspaco = true;
            }
        }

        if (tituloNormalizado.Length > 0 && ultimoCaractereFoiEspaco)
        {
            tituloNormalizado.Length--;
        }

        return tituloNormalizado.ToString().Normalize(NormalizationForm.FormC);
    }
}

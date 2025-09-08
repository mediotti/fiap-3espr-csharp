namespace CheckPoint1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=== CHECKPOINT 1 - FUNDAMENTOS C# - Turma  3ESPY ===\n");

            // ENTREGA ATÉ DIA 08/09 AS 23:59
            // Você deve criar um repositório público ou branch no github e me enviar o link pelo
            // teams antes do fim do prazo.
            // IMPORTANTE:
            // - Não haverá reposição do checkpoint.
            // - Fique atento ao prazo, nenhum trabalho será aceito após a data e vou me basear
            // - O link do seu git deve ser enviado no teams. A data e hora do recebimento do git será utilizada para verificar se foi enviado no prazo.
            // 

            // TODO: Implemente as chamadas de teste para demonstrar funcionamento
            // NÃO é obrigatório testar todos os caminhos/casos - apenas mostrar que funciona
            // Use valores de teste simples para validar cada implementação

            //  Treinem rodar o debugger.
            //  F9 - Coloca o breakpoint
            //  F10 - Passa sobre o método no passo a passo
            //  F11 - Entra nos métodos no passo a passo
            //  shift  + F11 - Volta do método

            Console.WriteLine("1. Testando DemonstrarTiposDados...");
            Console.WriteLine(DemonstrarTiposDados());

            Console.WriteLine("\n2. Testando CalculadoraBasica (SWITCH)...");
            Console.WriteLine($"10 + 5 = {CalculadoraBasica(10, 5, '+')}");
            Console.WriteLine($"10 / 0 = {CalculadoraBasica(10, 0, '/')}");
            Console.WriteLine($"Operador inválido: {CalculadoraBasica(10, 5, '%')}");

            Console.WriteLine("\n3. Testando ValidarIdade (IF/ELSE)...");
            Console.WriteLine($"Idade 5  -> {ValidarIdade(5)}");
            Console.WriteLine($"Idade 15 -> {ValidarIdade(15)}");
            Console.WriteLine($"Idade 30 -> {ValidarIdade(30)}");
            Console.WriteLine($"Idade 80 -> {ValidarIdade(80)}");
            Console.WriteLine($"Idade -1 -> {ValidarIdade(-1)}");

            Console.WriteLine("\n4. Testando ConverterString...");
            Console.WriteLine(ConverterString("123", "int"));
            Console.WriteLine(ConverterString("3,14", "double"));
            Console.WriteLine(ConverterString("true", "bool"));
            Console.WriteLine(ConverterString("abc", "int"));

            Console.WriteLine("\n5. Testando ClassificarNota (SWITCH)...");
            Console.WriteLine($"Nota 9.5  -> {ClassificarNota(9.5)}");
            Console.WriteLine($"Nota 8.0  -> {ClassificarNota(8.0)}");
            Console.WriteLine($"Nota 6.5  -> {ClassificarNota(6.5)}");
            Console.WriteLine($"Nota 4.0  -> {ClassificarNota(4.0)}");
            Console.WriteLine($"Nota 11.0 -> {ClassificarNota(11.0)}");

            Console.WriteLine("\n6. Testando GerarTabuada (FOR)...");
            Console.WriteLine(GerarTabuada(5));

            Console.WriteLine("\n7. Testando JogoAdivinhacao (WHILE)...");
            Console.WriteLine(JogoAdivinhacao(63, new int[] { 50, 75, 63 }));

            Console.WriteLine("\n8. Testando ValidarSenha (DO-WHILE)...");
            Console.WriteLine(ValidarSenha("MinhaSenh@123"));
            Console.WriteLine(ValidarSenha("fraca"));

            Console.WriteLine("\n9. Testando AnalisarNotas (FOREACH)...");
            Console.WriteLine(AnalisarNotas(new double[] { 8.5, 7.0, 9.2, 6.5, 10.0, 4.9, 8.0, 5.5 }));

            Console.WriteLine("\n10. Testando ProcessarVendas (FOREACH múltiplo)...");
            var vendas = new double[] { 500, 300, 700, 800, 200 };
            var categorias = new string[] { "A", "B", "A", "C", "B" };
            var nomesCategorias = new string[] { "A", "B", "C" };
            var comissoes = new double[] { 0.10, 0.07, 0.05 }; // A=10%, B=7%, C=5%
            Console.WriteLine(ProcessarVendas(vendas, categorias, comissoes, nomesCategorias));

            Console.WriteLine("\n=== RESUMO: TODAS AS ESTRUTURAS FORAM TESTADAS ===");
            Console.WriteLine("✅ IF/ELSE: Testado na validação de idade");
            Console.WriteLine("✅ SWITCH: Testado na calculadora e classificação de notas");
            Console.WriteLine("✅ FOR: Testado na tabuada");
            Console.WriteLine("✅ WHILE: Testado no jogo de adivinhação");
            Console.WriteLine("✅ DO-WHILE: Testado na validação de senha");
            Console.WriteLine("✅ FOREACH: Testado na análise de notas e processamento de vendas");

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadLine();
        }

        // =====================================================================
        // QUESTÃO 1 - VARIÁVEIS E TIPOS DE DADOS (10 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: Complete o método para demonstrar diferentes tipos de dados
        /// - Declare uma variável de cada tipo primitivo (int, double, bool, char, string)
        /// - Use inferência de tipos (var) onde apropriado
        /// - Retorne uma string concatenando todos os valores
        /// </summary>
        private static string DemonstrarTiposDados()
        {
            int inteiro = 42;
            double numDecimal = 3.14;
            bool booleano = true;
            char caractere = 'A';
            var texto = "Olá";

            return $"Inteiro: {inteiro}, Decimal: {numDecimal}, Booleano: {booleano}, Caractere: {caractere}, Texto: {texto}";
        }

        // =====================================================================
        // QUESTÃO 2 - OPERADORES ARITMÉTICOS (10 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: Implemente uma calculadora básica usando SWITCH
        /// - Receba dois números e um operador (+, -, *, /)
        /// - Use SWITCH para selecionar a operação
        /// - Trate divisão por zero retornando 0
        /// - Para operadores inválidos, retorne -1
        /// </summary>
        private static double CalculadoraBasica(double num1, double num2, char operador)
        {
            switch (operador)
            {
                case '+': return num1 + num2;
                case '-': return num1 - num2;
                case '*': return num1 * num2;
                case '/': return num2 == 0 ? 0 : num1 / num2;
                default: return -1;
            }
        }

        // =====================================================================
        // QUESTÃO 3 - OPERADORES RELACIONAIS E LÓGICOS (10 pontos)  
        // =====================================================================

        /// <summary>
        /// TODO: Valide se uma idade é válida para diferentes contextos usando IF/ELSE
        /// - Use IF/ELSE encadeados (não switch)
        /// - Retorna "Criança" se idade < 12
        /// - Retorna "Adolescente" se idade >= 12 e < 18  
        /// - Retorna "Adulto" se idade >= 18 e <= 65
        /// - Retorna "Idoso" se idade > 65
        /// - Retorna "Idade inválida" se idade < 0 ou > 120
        /// Use operadores relacionais e lógicos
        /// </summary>
        private static string ValidarIdade(int idade)
        {
            if (idade < 0 || idade > 120)
                return "Idade inválida";
            else if (idade < 12)
                return "Criança";
            else if (idade >= 12 && idade < 18)
                return "Adolescente";
            else if (idade >= 18 && idade <= 65)
                return "Adulto";
            else
                return "Idoso";
        }

        // =====================================================================
        // QUESTÃO 4 - CONVERSÃO DE TIPOS (10 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: Converta uma string para diferentes tipos
        /// - Tente converter 'valor' para int, double e bool
        /// - Se a conversão for bem-sucedida, retorne "Tipo: Valor convertido"
        /// - Se falhar, retorne "Conversão impossível para [tipo]"
        /// - Use TryParse para conversões seguras
        /// </summary>
        private static string ConverterString(string valor, string tipoDesejado)
        {
            if (string.IsNullOrWhiteSpace(tipoDesejado))
                return "Tipo não especificado";

            switch (tipoDesejado.Trim().ToLower())
            {
                case "int":
                    if (int.TryParse(valor, out int i))
                        return $"int: {i}";
                    return "Conversão impossível para int";

                case "double":
                    if (double.TryParse(valor, out double d))
                        return $"double: {d}";
                    return "Conversão impossível para double";

                case "bool":
                    if (bool.TryParse(valor, out bool b))
                        return $"bool: {b}";
                    return "Conversão impossível para bool";

                default:
                    return "Tipo não suportado";
            }
        }

        // =====================================================================
        // QUESTÃO 5 - ESTRUTURA CONDICIONAL SWITCH (10 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: Classifique uma nota usando switch expression (C# 8+) ou switch tradicional
        /// - 9.0 a 10.0: "Excelente"
        /// - 7.0 a 8.9: "Bom" 
        /// - 5.0 a 6.9: "Regular"
        /// - 0.0 a 4.9: "Insuficiente"
        /// - Fora da faixa: "Nota inválida"
        /// </summary>
        private static string ClassificarNota(double nota)
        {
            return nota switch
            {
                >= 9.0 and <= 10.0 => "Excelente",
                >= 7.0 and < 9.0 => "Bom",
                >= 5.0 and < 7.0 => "Regular",
                >= 0.0 and < 5.0 => "Insuficiente",
                _ => "Nota inválida"
            };
        }

        // =====================================================================
        // QUESTÃO 6 - ESTRUTURA FOR (10 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: OBRIGATÓRIO USAR FOR
        /// Gere a tabuada de um número de 1 a 10
        /// - Use FOR para iterar de 1 a 10
        /// - Retorne string formatada: "2 x 1 = 2\n2 x 2 = 4\n..." 
        /// - Se número for <= 0, retorne "Número inválido"
        /// </summary>
        private static string GerarTabuada(int numero)
        {
            if (numero <= 0) return "Número inválido";

            var sb = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                sb.AppendLine($"{numero} x {i} = {numero * i}");
            }
            return sb.ToString().TrimEnd();
        }

        // =====================================================================
        // QUESTÃO 7 - ESTRUTURA WHILE (15 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: OBRIGATÓRIO USAR WHILE
        /// Simule um jogo de adivinhar número com tentativas limitadas
        /// - numeroSecreto: número a ser adivinhado (1-100)
        /// - tentativas: array com os palpites do jogador
        /// - Use WHILE para percorrer as tentativas
        /// - Para cada tentativa: "Tentativa X: muito alto/baixo/correto"
        /// - Pare no acerto ou quando acabar as tentativas
        /// - Retorne string com histórico completo
        /// </summary>
        private static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
        {
            if (tentativas == null || tentativas.Length == 0)
                return "Sem tentativas";

            int i = 0;
            bool acertou = false;
            var sb = new StringBuilder();

            while (i < tentativas.Length && !acertou)
            {
                int palpite = tentativas[i];
                string avaliacao =
                    palpite == numeroSecreto ? "correto!" :
                    palpite < numeroSecreto ? "muito baixo" : "muito alto";

                sb.AppendLine($"Tentativa {i + 1}: {palpite} - {avaliacao}");

                if (palpite == numeroSecreto) acertou = true;
                i++;
            }

            return sb.ToString().TrimEnd();
        }

        // =====================================================================
        // QUESTÃO 8 - ESTRUTURA DO-WHILE (15 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: OBRIGATÓRIO USAR DO-WHILE
        /// Valide uma senha seguindo critérios de segurança
        /// - A senha deve ter pelo menos 8 caracteres
        /// - Deve ter pelo menos 1 número
        /// - Deve ter pelo menos 1 letra maiúscula  
        /// - Deve ter pelo menos 1 caractere especial (!@#$%&*)
        /// - Use DO-WHILE para verificar cada critério
        /// - Retorne string explicando quais critérios não foram atendidos
        /// - Se senha válida, retorne "Senha válida"
        /// </summary>
        private static string ValidarSenha(string senha)
        {
            if (senha == null) senha = string.Empty;

            bool temNumero = false;
            bool temMaiuscula = false;
            bool temEspecial = false;

            int idx = 0;
            if (senha.Length > 0)
            {
                do
                {
                    char c = senha[idx];
                    if (char.IsDigit(c)) temNumero = true;
                    if (char.IsUpper(c)) temMaiuscula = true;
                    if ("!@#$%&*".IndexOf(c) >= 0) temEspecial = true;

                    idx++;
                } while (idx < senha.Length);
            }

            var erros = new StringBuilder();
            if (senha.Length < 8) erros.AppendLine("- Pelo menos 8 caracteres");
            if (!temNumero) erros.AppendLine("- Pelo menos 1 número");
            if (!temMaiuscula) erros.AppendLine("- Pelo menos 1 letra maiúscula");
            if (!temEspecial) erros.AppendLine("- Pelo menos 1 caractere especial (!@#$%&*)");

            return erros.Length == 0 ? "Senha válida" : $"Senha inválida. Faltou:\n{erros.ToString().TrimEnd()}";
        }

        // =====================================================================
        // QUESTÃO 9 - ESTRUTURA FOREACH (15 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: OBRIGATÓRIO USAR FOREACH
        /// Analise um array de notas de alunos
        /// - Use FOREACH para percorrer todas as notas
        /// - Calcule: média, quantidade de aprovados (>=7), maior nota, menor nota
        /// - Conte quantas notas estão em cada faixa: A(9-10), B(8-8.9), C(7-7.9), D(5-6.9), F(<5)
        /// - Retorne string formatada com todas as estatísticas
        /// - Se array vazio/null: "Nenhuma nota para analisar"
        /// </summary>
        private static string AnalisarNotas(double[] notas)
        {
            if (notas == null || notas.Length == 0) return "Nenhuma nota para analisar";

            double soma = 0;
            int aprovados = 0;
            double maior = double.MinValue;
            double menor = double.MaxValue;

            int faA = 0, faB = 0, faC = 0, faD = 0, faF = 0;

            foreach (var n in notas)
            {
                soma += n;
                if (n >= 7.0) aprovados++;

                if (n > maior) maior = n;
                if (n < menor) menor = n;

                if (n >= 9.0 && n <= 10.0) faA++;
                else if (n >= 8.0 && n < 9.0) faB++;
                else if (n >= 7.0 && n < 8.0) faC++;
                else if (n >= 5.0 && n < 7.0) faD++;
                else if (n < 5.0) faF++;
            }

            double media = soma / notas.Length;

            return $"Média: {media:F2}\nAprovados: {aprovados}\nMaior: {maior:F1}\nMenor: {menor:F1}\nA: {faA}, B: {faB}, C: {faC}, D: {faD}, F: {faF}";
        }

        // =====================================================================
        // QUESTÃO 10 - MULTIPLE FOREACH (DESAFIO) (20 pontos)
        // =====================================================================

        /// <summary>
        /// TODO: OBRIGATÓRIO USAR FOREACH (múltiplos)
        /// Processe vendas por categoria e calcule comissões
        /// - vendas: array com valores de vendas
        /// - categorias: array com categorias correspondentes ("A", "B", "C")
        /// - comissoes: array com percentuais de comissão por categoria (ex: A=10%, B=7%, C=5%)
        /// - Use FOREACH para percorrer vendas e categorias simultaneamente
        /// - Use FOREACH separado para encontrar a comissão da categoria
        /// - Calcule total de vendas e total de comissões por categoria
        /// - Retorne string com relatório detalhado
        /// </summary>
        private static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
        {
            if (vendas == null || categorias == null || comissoes == null || nomesCategorias == null)
                return "Dados insuficientes";
            if (vendas.Length != categorias.Length)
                return "Vendas e categorias com tamanhos diferentes";

            var totaisVendas = nomesCategorias.ToDictionary(k => k, v => 0.0);
            var totaisComissoes = nomesCategorias.ToDictionary(k => k, v => 0.0);

            foreach (var par in vendas.Zip(categorias, (v, c) => new { Valor = v, Categoria = c }))
            {
                double taxa = 0.0;
                int idx = 0;
                foreach (var nome in nomesCategorias)
                {
                    if (string.Equals(nome, par.Categoria, StringComparison.OrdinalIgnoreCase))
                    {
                        if (idx >= 0 && idx < comissoes.Length)
                            taxa = comissoes[idx];
                        break;
                    }
                    idx++;
                }

                if (!totaisVendas.ContainsKey(par.Categoria))
                {
                    totaisVendas[par.Categoria] = 0.0;
                    totaisComissoes[par.Categoria] = 0.0;
                }

                totaisVendas[par.Categoria] += par.Valor;
                totaisComissoes[par.Categoria] += par.Valor * taxa;
            }

            var sb = new StringBuilder();
            foreach (var cat in totaisVendas.Keys.OrderBy(k => k))
            {
                sb.AppendLine($"Categoria {cat}: Vendas R$ {totaisVendas[cat]:N2}, Comissão R$ {totaisComissoes[cat]:N2}");
            }

            double totalGeralVendas = 0;
            double totalGeralComissoes = 0;
            foreach (var v in totaisVendas.Values) totalGeralVendas += v;
            foreach (var c in totaisComissoes.Values) totalGeralComissoes += c;

            sb.AppendLine($"TOTAL GERAL: Vendas R$ {totalGeralVendas:N2}, Comissões R$ {totalGeralComissoes:N2}");
            return sb.ToString().TrimEnd();
        }

        // =====================================================================
        // MÉTODOS AUXILIARES (NÃO ALTERAR - APENAS PARA REFERÊNCIA)
        // =====================================================================

        /// <summary>
        /// Método de exemplo demonstrando diferença entre estático e de instância
        /// ESTÁTICO: Pertence à classe, não precisa criar objeto para usar
        /// </summary>
        private static void ExemploMetodoEstatico()
        {
            Console.WriteLine("Sou um método estático - chamado direto da classe");
        }

        /// <summary>
        /// Método de exemplo de instância (comentado pois não pode ser chamado do Main estático)
        /// DE INSTÂNCIA: Pertence ao objeto, precisa criar instância da classe
        /// </summary>
        /*
        void ExemploMetodoInstancia()
        {
            Console.WriteLine("Sou um método de instância - preciso de um objeto para ser chamado");
        }
        */
    }
}

<p align="center">
    <image src="https://github.com/vinnybrito/OceanGuard/assets/111714040/743b0356-8cb7-4021-8d5a-64470b7e752d" width="300" height="300"></image>
</p>
<p align="center">
    <a href="https://youtu.be/iMiFVYaS4Lw">Link do Vídeo Pitch</a>
</p>

# OceanGuard - Global Solution (FIAP)
<p>
    O OceanGuard é um aplicativo inovador desenvolvido para auxiliar moradores e banhistas das praias a relatar e 
    monitorar as condições ambientais e atividades humanas nessas áreas, promovendo a conservação e gestão 
    sustentável do ambiente costeiro.
</p>

### Integrantes do Grupo
- Gustavo Guarnieri de Melo...........RM: 97100
- Gustavo Santos Nascimento........RM: 96687
- Vinícius Almeida Kotchetkoff.......RM: 96331
- Vinicius Rodrigues Brito.................RM: 97473
- William Mendes Vulcano...............RM: 96939

<hr/>

<p align="center">
    <a href="https://www.figma.com/design/lDgboP6uHHmBhWHv1S8NWn/OceanGuard---Prot%C3%B3tipo-do-App?node-id=0-1&t=mFQRQd5GczVxm8cw-1" target="_blank">
        Protótipo no Figma
    </a>
</p>

<!-- ----------------------- ESCOPO DO PROJETO ----------------------- -->

<details>
    <summary>
        <h3>Escopo do Projeto</h3>
    </summary>
    <p>
        Os oceanos desempenham um papel crucial na manutenção da vida na Terra, proporcionando alimentos, regulando o clima e
        sustentando uma vasta biodiversidade. No entanto, as atividades humanas têm causado impactos significativos nos 
        ecossistemas marinhos, incluindo a destruição de habitats, poluição e mudanças climáticas. Esses desafios não apenas 
        ameaçam os ecossistemas marinhos, mas também têm consequências econômicas e sociais globais.
    </p>
    <p>
        O projeto OceanGuard visa garantir que as atividades humanas nos oceanos sejam ecologicamente responsáveis, socialmente 
        inclusivas e economicamente viáveis a longo prazo. Para alcançar isso, o projeto se concentra em:
    </p>
    <details>
         <summary>
             <h4>Objetivos<h4/>
         </summary>
         <p>
             1. <strong>Gestão Ambiental:</strong> Promover práticas sustentáveis na gestão dos recursos marinhos. <br>
             2. <strong>Tecnologias Inovadoras:</strong> Utilizar tecnologias avançadas para monitorar e mitigar os impactos ambientais. <br>
             3. <strong>Colaboração Multissetorial:</strong> Fomentar a cooperação entre governos, empresas e comunidades locais para a conservação marinha.
         </p>
    </details>
    <details>
         <summary>
             <h4>Proposta de Solução<h4/>
        </summary>
         <p>
             O OceanGuard é um aplicativo móvel destinado a moradores, turistas, visitantes e banhistas que frequentam praias. Ele proporciona
             uma plataforma para reportar e monitorar condições ambientais e atividades humanas nas praias. As principais funcionalidades do
             aplicativo incluem:
         </p>    
    </details>
</details>
 <!-- ----------------------- EXECUTAR O PROJETO - ENTERPRISE APPLICATION DEVELOPMENT ----------------------- -->
<details>
    <summary>
        <h3>Executar o projeto - ENTERPRISE APPLICATION DEVELOPMENT</h3>
    </summary>
    <p>Para executar o projeto, siga os seguintes passos:</p>
    <ol>
        <li>Abrir o projeto.</li>
        <li>Se necessário, alterar o login do OracleBD, vá até a classe <code>Program</code>.</li>
        <li>Abrir o <code>Window Package Manage Console</code> e digitar os seguintes comandos:
            <ul>
                <li><code>add-migrations TesteGS</code> - Para criar uma migration</li>
                <li><code>update-database</code> - Para criar ou atualizar as tabelas no OracleBD</li>
            </ul>
        </li>
        <li>Verifique se as tabelas foram criadas corretamente.</li>
        <li>No VS, abrir um Terminal e digitar os seguintes comandos:
            <ul>
                <li><code>cd OceanGuard</code></li>
                <li><code>dotnet run seeddata</code> (pressione Ctrl + C depois de rodar o comando acima)</li>
            </ul>
        </li>
        <li>Rodar o projeto e testar.</li>
    </ol>
    <p>Ordem dos endpoints:</p>
    <ol>
        <li>Usuário</li>
        <li>OcorrênciaLixo - EventoNatural - DensidadeBanhista</li>
        <li>Autoridade</li>
        <li>Notificação</li>
    </ol>
    <details>
        <summary>
            <h3>Endereços dos Endpoints</h3>
        </summary>
        <ul>
            <li>Autoridade: <a href="https://localhost:7168/api/Autoridade">https://localhost:7168/api/Autoridade</a></li>
            <li>Usuário: <a href="https://localhost:7168/api/Usuario">https://localhost:7168/api/Usuario</a></li>
            <li>DensidadeBanhista: <a href="https://localhost:7168/api/DensidadeBanhista">https://localhost:7168/api/DensidadeBanhista</a></li>
            <li>EventoNatural: <a href="https://localhost:7168/api/EventoNatural">https://localhost:7168/api/EventoNatural</a></li>
            <li>OcorrenciaLixo: <a href="https://localhost:7168/api/OcorrenciaLixo">https://localhost:7168/api/OcorrenciaLixo</a></li>
            <li>Notificação: <a href="https://localhost:7168/api/Notificacao">https://localhost:7168/api/Notificacao</a></li>
        </ul>
    </details>
    <details>
        <summary>
            <h3>Exemplos de JSONs</h3>
        </summary>

<h4>Usuário JSON</h4>
    <pre>
<code>[
    {
        "Nome": "Alice",
        "Email": "alice@example.com",
        "Senha": "password123",
        "DataCadastro": "2024-06-05T00:00:00"
    },
    {
        "Nome": "Bob",
        "Email": "bob@example.com",
        "Senha": "password456",
        "DataCadastro": "2024-06-05T00:00:00"
    }
]</code>
    </pre>

<h4>OcorrênciaLixo JSON</h4>
    <pre>
<code>[
    {
        "Descricao": "Lixo na praia",
        "Latitude": -23.5505,
        "Longitude": -46.6333,
        "DataOcorrencia": "2024-06-04T00:00:00",
        "Usuario": {
            "Nome": "Alice",
            "Email": "alice@example.com",
            "Senha": "password123",
            "DataCadastro": "2024-06-05T00:00:00"
        }
    },
    {
        "Descricao": "Resíduos plásticos",
        "Latitude": -22.9083,
        "Longitude": -43.1964,
        "DataOcorrencia": "2024-06-03T00:00:00",
        "Usuario": {
            "Nome": "Bob",
            "Email": "bob@example.com",
            "Senha": "password456",
            "DataCadastro": "2024-06-05T00:00:00"
        }
    }
]</code>
</pre>

<h4>EventoNatural JSON</h4>
    <pre>
<code>[
    {
        "Descricao": "Tempestade tropical",
        "Tipo": "Tempestade",
        "Latitude": -15.7801,
        "Longitude": -47.9292,
        "DataEvento": "2024-05-31T00:00:00",
        "Usuario": {
            "Nome": "Alice",
            "Email": "alice@example.com",
            "Senha": "password123",
            "DataCadastro": "2024-06-05T00:00:00"
        }
    },
    {
        "Descricao": "Deslizamento de terra",
        "Tipo": "Deslizamento",
        "Latitude": -19.9167,
        "Longitude": -43.9345,
        "DataEvento": "2024-05-26T00:00:00",
        "Usuario": {
            "Nome": "Bob",
            "Email": "bob@example.com",
            "Senha": "password456",
            "DataCadastro": "2024-06-05T00:00:00"
        }
    }
]</code>
    </pre>

<h4>DensidadeBanhista JSON</h4>
    <pre>
<code>[
    {
        "QuantidadeBanhistas": 100,
        "Latitude": -23.5505,
        "Longitude": -46.6333,
        "DataReporte": "2024-06-05T00:00:00",
        "Usuario": {
            "Nome": "Alice",
            "Email": "alice@example.com",
            "Senha": "password123",
            "DataCadastro": "2024-06-05T00:00:00"
        }
    },
    {
        "QuantidadeBanhistas": 200,
        "Latitude": -22.9083,
        "Longitude": -43.1964,
        "DataReporte": "2024-06-05T00:00:00",
        "Usuario": {
            "Nome": "Bob",
            "Email": "bob@example.com",
            "Senha": "password456",
            "DataCadastro": "2024-06-05T00:00:00"
        }
    }
]</code>
    </pre>

<h4>Autoridade JSON</h4>
    <pre>
<code>[
    {
        "Nome": "Autoridade A",
        "Contato": "contatoA@example.com"
    },
    {
        "Nome": "Autoridade B",
        "Contato": "contatoB@example.com"
    }
]</code>
    </pre>

<h4>Notificação JSON</h4>
    <pre>
<code>[
    {
        "DataNotificacao": "2024-06-05T00:00:00",
        "Status": "Pendente",
        "Autoridade": {
            "Nome": "Autoridade A",
            "Contato": "contatoA@example.com"
        },
        "OcorrenciaLixo": {
            "Descricao": "Lixo na praia",
            "Latitude": -23.5505,
            "Longitude": -46.6333,
            "DataOcorrencia": "2024-06-04T00:00:00",
            "Usuario": {
                "Nome": "Alice",
                "Email": "alice@example.com",
                "Senha": "password123",
                "DataCadastro": "2024-06-05T00:00:00"
            }
        }
    },
    {
        "DataNotificacao": "2024-06-05T00:00:00",
        "Status": "Resolvido",
        "Autoridade": {
            "Nome": "Autoridade B",
            "Contato": "contatoB@example.com"
        },
        "EventoNatural": {
            "Descricao": "Tempestade tropical",
            "Tipo": "Tempestade",
            "Latitude": -15.7801,
            "Longitude": -47.9292,
            "DataEvento": "2024-05-31T00:00:00",
            "Usuario": {
                "Nome": "Alice",
                "Email": "alice@example.com",
                "Senha": "password123",
                "DataCadastro": "2024-06-05T00:00:00"
            }
        }
    }
]</code>
    </pre>
    </details>
</details>

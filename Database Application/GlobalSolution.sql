DROP TABLE notificacoes CASCADE CONSTRAINTS;
DROP TABLE autoridades CASCADE CONSTRAINTS;
DROP TABLE eventos_naturais CASCADE CONSTRAINTS;
DROP TABLE densidade_banhistas CASCADE CONSTRAINTS;
DROP TABLE ocorrencias_lixo CASCADE CONSTRAINTS;
DROP TABLE usuarios CASCADE CONSTRAINTS;

CREATE TABLE usuarios (
    id_usuario NUMBER(7) PRIMARY KEY,
    nome VARCHAR2(60),
    email VARCHAR2(60),
    senha VARCHAR2(30),
    data_cadastro DATE
);

CREATE TABLE ocorrencias_lixo (
    id_ocorrencia_lixo NUMBER(7) PRIMARY KEY,
    descricao VARCHAR2(100),
    latitude NUMBER(7,2),
    longitude NUMBER(7,2),
    data_ocorrencia DATE,
    fk_usuarios_id_usuario NUMBER(7),
    FOREIGN KEY (fk_usuarios_id_usuario) REFERENCES usuarios (id_usuario)
);

CREATE TABLE densidade_banhistas (
    id_densidade NUMBER(7) PRIMARY KEY,
    quantidade_banhistas NUMBER(7),
    latitude NUMBER(7,2),
    longitude NUMBER(7,2),
    data_report DATE,
    fk_usuarios_id_usuario NUMBER(7),
    FOREIGN KEY (fk_usuarios_id_usuario) REFERENCES usuarios (id_usuario)
);

CREATE TABLE eventos_naturais (
    id_evento NUMBER(7) PRIMARY KEY,
    descricao VARCHAR2(100),
    tipo VARCHAR2(30),
    latitude NUMBER(7,2),
    longitude NUMBER(7,2),
    data_evento DATE,
    fk_usuarios_id_usuario NUMBER(7),
    FOREIGN KEY (fk_usuarios_id_usuario) REFERENCES usuarios (id_usuario)
);

CREATE TABLE autoridades (
    id_autoridade NUMBER(7) PRIMARY KEY,
    nome VARCHAR2(60),
    contato VARCHAR2(20)
);

CREATE TABLE notificacoes (
    id_notificacao NUMBER(7) PRIMARY KEY,
    data_notificacao DATE,
    status VARCHAR2(30),
    fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER(7),
    fk_densidade_banhistas_id_densidade NUMBER(7),
    fk_eventos_naturais_id_evento NUMBER(7),
    fk_autoridades_id_autoridade NUMBER(7),
    FOREIGN KEY (fk_ocorrencias_lixo_id_ocorrencia_lixo) REFERENCES ocorrencias_lixo (id_ocorrencia_lixo),
    FOREIGN KEY (fk_densidade_banhistas_id_densidade) REFERENCES densidade_banhistas (id_densidade),
    FOREIGN KEY (fk_eventos_naturais_id_evento) REFERENCES eventos_naturais (id_evento),
    FOREIGN KEY (fk_autoridades_id_autoridade) REFERENCES autoridades (id_autoridade)
);

-- Inserts for table 'usuarios'
INSERT INTO usuarios (id_usuario, nome, email, senha, data_cadastro) VALUES (1, 'João Silva', 'joao.silva@example.com', 'senha123', TO_DATE('2023-01-01', 'YYYY-MM-DD'));
INSERT INTO usuarios (id_usuario, nome, email, senha, data_cadastro) VALUES (2, 'Maria Souza', 'maria.souza@example.com', 'senha456', TO_DATE('2023-02-01', 'YYYY-MM-DD'));
INSERT INTO usuarios (id_usuario, nome, email, senha, data_cadastro) VALUES (3, 'Carlos Pereira', 'carlos.pereira@example.com', 'senha789', TO_DATE('2023-03-01', 'YYYY-MM-DD'));
INSERT INTO usuarios (id_usuario, nome, email, senha, data_cadastro) VALUES (4, 'Ana Lima', 'ana.lima@example.com', 'senha321', TO_DATE('2023-04-01', 'YYYY-MM-DD'));
INSERT INTO usuarios (id_usuario, nome, email, senha, data_cadastro) VALUES (5, 'Beatriz Oliveira', 'beatriz.oliveira@example.com', 'senha654', TO_DATE('2023-05-01', 'YYYY-MM-DD'));

-- Inserts for table 'ocorrencias_lixo'
INSERT INTO ocorrencias_lixo (id_ocorrencia_lixo, descricao, latitude, longitude, data_ocorrencia, fk_usuarios_id_usuario) VALUES (1, 'Lixo na praia', -23.55, -46.63, TO_DATE('2023-01-10', 'YYYY-MM-DD'), 1);
INSERT INTO ocorrencias_lixo (id_ocorrencia_lixo, descricao, latitude, longitude, data_ocorrencia, fk_usuarios_id_usuario) VALUES (2, 'Descarte irregular de lixo', -23.56, -46.64, TO_DATE('2023-02-15', 'YYYY-MM-DD'), 2);
INSERT INTO ocorrencias_lixo (id_ocorrencia_lixo, descricao, latitude, longitude, data_ocorrencia, fk_usuarios_id_usuario) VALUES (3, 'Resíduos plásticos', -23.57, -46.65, TO_DATE('2023-03-20', 'YYYY-MM-DD'), 3);
INSERT INTO ocorrencias_lixo (id_ocorrencia_lixo, descricao, latitude, longitude, data_ocorrencia, fk_usuarios_id_usuario) VALUES (4, 'Lixo hospitalar', -23.58, -46.66, TO_DATE('2023-04-25', 'YYYY-MM-DD'), 4);
INSERT INTO ocorrencias_lixo (id_ocorrencia_lixo, descricao, latitude, longitude, data_ocorrencia, fk_usuarios_id_usuario) VALUES (5, 'Lixo eletrônico', -23.59, -46.67, TO_DATE('2023-05-30', 'YYYY-MM-DD'), 5);

-- Inserts for table 'densidade_banhistas'
INSERT INTO densidade_banhistas (id_densidade, quantidade_banhistas, latitude, longitude, data_report, fk_usuarios_id_usuario) VALUES (1, 50, -23.55, -46.63, TO_DATE('2023-01-05', 'YYYY-MM-DD'), 1);
INSERT INTO densidade_banhistas (id_densidade, quantidade_banhistas, latitude, longitude, data_report, fk_usuarios_id_usuario) VALUES (2, 75, -23.56, -46.64, TO_DATE('2023-02-10', 'YYYY-MM-DD'), 2);
INSERT INTO densidade_banhistas (id_densidade, quantidade_banhistas, latitude, longitude, data_report, fk_usuarios_id_usuario) VALUES (3, 100, -23.57, -46.65, TO_DATE('2023-03-15', 'YYYY-MM-DD'), 3);
INSERT INTO densidade_banhistas (id_densidade, quantidade_banhistas, latitude, longitude, data_report, fk_usuarios_id_usuario) VALUES (4, 125, -23.58, -46.66, TO_DATE('2023-04-20', 'YYYY-MM-DD'), 4);
INSERT INTO densidade_banhistas (id_densidade, quantidade_banhistas, latitude, longitude, data_report, fk_usuarios_id_usuario) VALUES (5, 150, -23.59, -46.67, TO_DATE('2023-05-25', 'YYYY-MM-DD'), 5);

-- Inserts for table 'eventos_naturais'
INSERT INTO eventos_naturais (id_evento, descricao, tipo, latitude, longitude, data_evento, fk_usuarios_id_usuario) VALUES (1, 'Tempestade', 'Climático', -23.55, -46.63, TO_DATE('2023-01-12', 'YYYY-MM-DD'), 1);
INSERT INTO eventos_naturais (id_evento, descricao, tipo, latitude, longitude, data_evento, fk_usuarios_id_usuario) VALUES (2, 'Deslizamento', 'Geológico', -23.56, -46.64, TO_DATE('2023-02-17', 'YYYY-MM-DD'), 2);
INSERT INTO eventos_naturais (id_evento, descricao, tipo, latitude, longitude, data_evento, fk_usuarios_id_usuario) VALUES (3, 'Tsunami', 'Marítimo', -23.57, -46.65, TO_DATE('2023-03-22', 'YYYY-MM-DD'), 3);
INSERT INTO eventos_naturais (id_evento, descricao, tipo, latitude, longitude, data_evento, fk_usuarios_id_usuario) VALUES (4, 'Terremoto', 'Geológico', -23.58, -46.66, TO_DATE('2023-04-27', 'YYYY-MM-DD'), 4);
INSERT INTO eventos_naturais (id_evento, descricao, tipo, latitude, longitude, data_evento, fk_usuarios_id_usuario) VALUES (5, 'Incêndio florestal', 'Biológico', -23.59, -46.67, TO_DATE('2023-05-31', 'YYYY-MM-DD'), 5);

INSERT INTO autoridades (id_autoridade, nome, contato) VALUES (1, 'Polícia Ambiental', '1234-5678');
INSERT INTO autoridades (id_autoridade, nome, contato) VALUES (2, 'Defesa Civil', '2345-6789');
INSERT INTO autoridades (id_autoridade, nome, contato) VALUES (3, 'Corpo de Bombeiros', '3456-7890');
INSERT INTO autoridades (id_autoridade, nome, contato) VALUES (4, 'Prefeitura Municipal', '4567-8901');
INSERT INTO autoridades (id_autoridade, nome, contato) VALUES (5, 'Guarda Municipal', '5678-9012');

INSERT INTO notificacoes (id_notificacao, data_notificacao, status, fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade) VALUES (1, TO_DATE('2023-01-13', 'YYYY-MM-DD'), 'Enviado', 1, 1, 1, 1);
INSERT INTO notificacoes (id_notificacao, data_notificacao, status, fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade) VALUES (2, TO_DATE('2023-02-18', 'YYYY-MM-DD'), 'Enviado', 2, 2, 2, 2);
INSERT INTO notificacoes (id_notificacao, data_notificacao, status, fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade) VALUES (3, TO_DATE('2023-03-23', 'YYYY-MM-DD'), 'Enviado', 3, 3, 3, 3);
INSERT INTO notificacoes (id_notificacao, data_notificacao, status, fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade) VALUES (4, TO_DATE('2023-04-28', 'YYYY-MM-DD'), 'Enviado', 4, 4, 4, 4);
INSERT INTO notificacoes (id_notificacao, data_notificacao, status, fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade) VALUES (5, TO_DATE('2023-06-01', 'YYYY-MM-DD'), 'Enviado', 5, 5, 5, 5);


set serveroutput on

----Packages----

---INSERIR---

CREATE OR REPLACE PACKAGE inserir AS
    PROCEDURE inserir_usuario(
        p_id_usuario NUMBER,
        p_nome VARCHAR2,
        p_email VARCHAR2,
        p_senha VARCHAR2,
        p_data_cadastro DATE
    );

    PROCEDURE inserir_autoridade(
        p_id_autoridade NUMBER,
        p_nome VARCHAR2,
        p_contato VARCHAR2
    );

    PROCEDURE inserir_ocorrencia_lixo(
        p_id_ocorrencia_lixo NUMBER,
        p_descricao VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_ocorrencia DATE,
        p_fk_usuarios_id_usuario NUMBER
    );

    PROCEDURE inserir_densidade_banhistas(
        p_id_densidade NUMBER,
        p_quantidade_banhistas NUMBER,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_report DATE,
        p_fk_usuarios_id_usuario NUMBER
    );

    PROCEDURE inserir_evento_natural(
        p_id_evento NUMBER,
        p_descricao VARCHAR2,
        p_tipo VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_evento DATE,
        p_fk_usuarios_id_usuario NUMBER
    );

    PROCEDURE inserir_notificacao(
        p_id_notificacao NUMBER,
        p_data_notificacao DATE,
        p_status VARCHAR2,
        p_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER,
        p_fk_densidade_banhistas_id_densidade NUMBER,
        p_fk_eventos_naturais_id_evento NUMBER,
        p_fk_autoridades_id_autoridade NUMBER
    );
END inserir;
/


CREATE OR REPLACE PACKAGE BODY inserir AS

    PROCEDURE inserir_usuario(
        p_id_usuario NUMBER,
        p_nome VARCHAR2,
        p_email VARCHAR2,
        p_senha VARCHAR2,
        p_data_cadastro DATE
    ) IS
    BEGIN
        -- Validações
        IF p_id_usuario IS NULL OR p_nome IS NULL OR p_email IS NULL OR p_senha IS NULL OR p_data_cadastro IS NULL THEN
            RAISE_APPLICATION_ERROR(-20001, 'Todos os campos são obrigatórios.');
        END IF;

        INSERT INTO usuarios (id_usuario, nome, email, senha, data_cadastro)
        VALUES (p_id_usuario, p_nome, p_email, p_senha, p_data_cadastro);
    END inserir_usuario;

    PROCEDURE inserir_autoridade(
        p_id_autoridade NUMBER,
        p_nome VARCHAR2,
        p_contato VARCHAR2
    ) IS
    BEGIN
        -- Validações
        IF p_id_autoridade IS NULL OR p_nome IS NULL OR p_contato IS NULL THEN
            RAISE_APPLICATION_ERROR(-20002, 'Todos os campos são obrigatórios.');
        END IF;

        INSERT INTO autoridades (id_autoridade, nome, contato)
        VALUES (p_id_autoridade, p_nome, p_contato);
    END inserir_autoridade;

    PROCEDURE inserir_ocorrencia_lixo(
        p_id_ocorrencia_lixo NUMBER,
        p_descricao VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_ocorrencia DATE,
        p_fk_usuarios_id_usuario NUMBER
    ) IS
    BEGIN
        -- Validações
        IF p_id_ocorrencia_lixo IS NULL OR p_descricao IS NULL OR p_latitude IS NULL OR p_longitude IS NULL OR p_data_ocorrencia IS NULL OR p_fk_usuarios_id_usuario IS NULL THEN
            RAISE_APPLICATION_ERROR(-20003, 'Todos os campos são obrigatórios.');
        END IF;

        INSERT INTO ocorrencias_lixo (id_ocorrencia_lixo, descricao, latitude, longitude, data_ocorrencia, fk_usuarios_id_usuario)
        VALUES (p_id_ocorrencia_lixo, p_descricao, p_latitude, p_longitude, p_data_ocorrencia, p_fk_usuarios_id_usuario);
    END inserir_ocorrencia_lixo;

    PROCEDURE inserir_densidade_banhistas(
        p_id_densidade NUMBER,
        p_quantidade_banhistas NUMBER,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_report DATE,
        p_fk_usuarios_id_usuario NUMBER
    ) IS
    BEGIN
        -- Validações
        IF p_id_densidade IS NULL OR p_quantidade_banhistas IS NULL OR p_latitude IS NULL OR p_longitude IS NULL OR p_data_report IS NULL OR p_fk_usuarios_id_usuario IS NULL THEN
            RAISE_APPLICATION_ERROR(-20004, 'Todos os campos são obrigatórios.');
        END IF;

        INSERT INTO densidade_banhistas (id_densidade, quantidade_banhistas, latitude, longitude, data_report, fk_usuarios_id_usuario)
        VALUES (p_id_densidade, p_quantidade_banhistas, p_latitude, p_longitude, p_data_report, p_fk_usuarios_id_usuario);
    END inserir_densidade_banhistas;

    PROCEDURE inserir_evento_natural(
        p_id_evento NUMBER,
        p_descricao VARCHAR2,
        p_tipo VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_evento DATE,
        p_fk_usuarios_id_usuario NUMBER
    ) IS
    BEGIN
        -- Validações
        IF p_id_evento IS NULL OR p_descricao IS NULL OR p_tipo IS NULL OR p_latitude IS NULL OR p_longitude IS NULL OR p_data_evento IS NULL OR p_fk_usuarios_id_usuario IS NULL THEN
            RAISE_APPLICATION_ERROR(-20005, 'Todos os campos são obrigatórios.');
        END IF;

        INSERT INTO eventos_naturais (id_evento, descricao, tipo, latitude, longitude, data_evento, fk_usuarios_id_usuario)
        VALUES (p_id_evento, p_descricao, p_tipo, p_latitude, p_longitude, p_data_evento, p_fk_usuarios_id_usuario);
    END inserir_evento_natural;

    PROCEDURE inserir_notificacao(
        p_id_notificacao NUMBER,
        p_data_notificacao DATE,
        p_status VARCHAR2,
        p_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER,
        p_fk_densidade_banhistas_id_densidade NUMBER,
        p_fk_eventos_naturais_id_evento NUMBER,
        p_fk_autoridades_id_autoridade NUMBER
    ) IS
    BEGIN
        -- Validações
        IF p_id_notificacao IS NULL OR p_data_notificacao IS NULL OR p_status IS NULL THEN
            RAISE_APPLICATION_ERROR(-20006, 'Campos id_notificacao, data_notificacao e status são obrigatórios.');
        END IF;

        IF p_fk_ocorrencias_lixo_id_ocorrencia_lixo IS NULL AND p_fk_densidade_banhistas_id_densidade IS NULL AND p_fk_eventos_naturais_id_evento IS NULL THEN
            RAISE_APPLICATION_ERROR(-20007, 'Pelo menos um dos campos de chave estrangeira deve ser preenchido.');
        END IF;

        IF p_fk_autoridades_id_autoridade IS NULL THEN
            RAISE_APPLICATION_ERROR(-20008, 'O campo fk_autoridades_id_autoridade é obrigatório.');
        END IF;

        INSERT INTO notificacoes (id_notificacao, data_notificacao, status, fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade)
        VALUES (p_id_notificacao, p_data_notificacao, p_status, p_fk_ocorrencias_lixo_id_ocorrencia_lixo, p_fk_densidade_banhistas_id_densidade, p_fk_eventos_naturais_id_evento, p_fk_autoridades_id_autoridade);
    END inserir_notificacao;

END inserir;
/


---TESTE INSERIR




DECLARE
    v_id_usuario NUMBER := 6;
    v_nome VARCHAR2(60) := 'Gustavo Guarnieri';
    v_email VARCHAR2(60) := 'gustavo.guarnieri@gmail.com';
    v_senha VARCHAR2(30) := 'senha123';
    v_data_cadastro DATE := SYSDATE;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando inserção na tabela usuarios');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_usuario: ' || v_id_usuario);
    DBMS_OUTPUT.PUT_LINE('nome: ' || v_nome);
    DBMS_OUTPUT.PUT_LINE('email: ' || v_email);
    DBMS_OUTPUT.PUT_LINE('senha: ' || v_senha);
    DBMS_OUTPUT.PUT_LINE('data_cadastro: ' || v_data_cadastro);

    inserir.inserir_usuario(v_id_usuario, v_nome, v_email, v_senha, v_data_cadastro);
    
    DBMS_OUTPUT.PUT_LINE('Inserção concluída com sucesso');
END;
/
SELECT * FROM usuarios;

DECLARE
    v_id_autoridade NUMBER := 6;
    v_nome VARCHAR2(60) := 'Policia Ambiental';
    v_contato VARCHAR2(20) := '1234-5678';
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando inserção na tabela autoridades');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_autoridade: ' || v_id_autoridade);
    DBMS_OUTPUT.PUT_LINE('nome: ' || v_nome);
    DBMS_OUTPUT.PUT_LINE('contato: ' || v_contato);

    inserir.inserir_autoridade(v_id_autoridade, v_nome, v_contato);
    
    DBMS_OUTPUT.PUT_LINE('Inserção concluída com sucesso');
END;
/
SELECT * FROM autoridades;

DECLARE
    v_id_ocorrencia_lixo NUMBER := 6;
    v_descricao VARCHAR2(100) := 'Lixo na praia';
    v_latitude NUMBER := 34.50;
    v_longitude NUMBER := 120.50;
    v_data_ocorrencia DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 6;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando inserção na tabela ocorrencias_lixo');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_ocorrencia_lixo: ' || v_id_ocorrencia_lixo);
    DBMS_OUTPUT.PUT_LINE('descricao: ' || v_descricao);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_ocorrencia: ' || v_data_ocorrencia);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    inserir.inserir_ocorrencia_lixo(v_id_ocorrencia_lixo, v_descricao, v_latitude, v_longitude, v_data_ocorrencia, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Inserção concluída com sucesso');
END;
/
SELECT * FROM ocorrencias_lixo;


DECLARE
    v_id_densidade NUMBER := 6;
    v_quantidade_banhistas NUMBER := 150;
    v_latitude NUMBER := 34.50;
    v_longitude NUMBER := 120.50;
    v_data_report DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 6;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando inserção na tabela densidade_banhistas');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_densidade: ' || v_id_densidade);
    DBMS_OUTPUT.PUT_LINE('quantidade_banhistas: ' || v_quantidade_banhistas);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_report: ' || v_data_report);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    inserir.inserir_densidade_banhistas(v_id_densidade, v_quantidade_banhistas, v_latitude, v_longitude, v_data_report, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Inserção concluída com sucesso');
END;
/
SELECT * FROM densidade_banhistas;

DECLARE
    v_id_evento NUMBER := 6;
    v_descricao VARCHAR2(100) := 'Tempestade';
    v_tipo VARCHAR2(30) := 'Chuva';
    v_latitude NUMBER := 34.50;
    v_longitude NUMBER := 120.50;
    v_data_evento DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 6;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando inserção na tabela eventos_naturais');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_evento: ' || v_id_evento);
    DBMS_OUTPUT.PUT_LINE('descricao: ' || v_descricao);
    DBMS_OUTPUT.PUT_LINE('tipo: ' || v_tipo);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_evento: ' || v_data_evento);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    inserir.inserir_evento_natural(v_id_evento, v_descricao, v_tipo, v_latitude, v_longitude, v_data_evento, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Inserção concluída com sucesso');
END;
/
SELECT * FROM eventos_naturais;

DECLARE
    v_id_notificacao NUMBER := 6;
    v_data_notificacao DATE := SYSDATE;
    v_status VARCHAR2(30) := 'Pendente';
    v_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER := 6;
    v_fk_densidade_banhistas_id_densidade NUMBER := 6;
    v_fk_eventos_naturais_id_evento NUMBER := 6;
    v_fk_autoridades_id_autoridade NUMBER := 6;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando inserção na tabela notificacoes');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_notificacao: ' || v_id_notificacao);
    DBMS_OUTPUT.PUT_LINE('data_notificacao: ' || v_data_notificacao);
    DBMS_OUTPUT.PUT_LINE('status: ' || v_status);
    DBMS_OUTPUT.PUT_LINE('fk_ocorrencias_lixo_id_ocorrencia_lixo: ' || v_fk_ocorrencias_lixo_id_ocorrencia_lixo);
    DBMS_OUTPUT.PUT_LINE('fk_densidade_banhistas_id_densidade: ' || v_fk_densidade_banhistas_id_densidade);
    DBMS_OUTPUT.PUT_LINE('fk_eventos_naturais_id_evento: ' || v_fk_eventos_naturais_id_evento);
    DBMS_OUTPUT.PUT_LINE('fk_autoridades_id_autoridade: ' || v_fk_autoridades_id_autoridade);

    inserir.inserir_notificacao(
        v_id_notificacao,
        v_data_notificacao,
        v_status,
        v_fk_ocorrencias_lixo_id_ocorrencia_lixo,
        v_fk_densidade_banhistas_id_densidade,
        v_fk_eventos_naturais_id_evento,
        v_fk_autoridades_id_autoridade
    );

    DBMS_OUTPUT.PUT_LINE('Inserção concluída com sucesso');
END;
/
SELECT * FROM notificacoes;




---ATUALIZAR




CREATE OR REPLACE PACKAGE atualizar AS
    PROCEDURE atualizar_usuario(
        p_id_usuario NUMBER,
        p_nome VARCHAR2,
        p_email VARCHAR2,
        p_senha VARCHAR2,
        p_data_cadastro DATE
    );

    PROCEDURE atualizar_autoridade(
        p_id_autoridade NUMBER,
        p_nome VARCHAR2,
        p_contato VARCHAR2
    );

    PROCEDURE atualizar_ocorrencia_lixo(
        p_id_ocorrencia_lixo NUMBER,
        p_descricao VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_ocorrencia DATE,
        p_fk_usuarios_id_usuario NUMBER
    );

    PROCEDURE atualizar_densidade_banhistas(
        p_id_densidade NUMBER,
        p_quantidade_banhistas NUMBER,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_report DATE,
        p_fk_usuarios_id_usuario NUMBER
    );

    PROCEDURE atualizar_evento_natural(
        p_id_evento NUMBER,
        p_descricao VARCHAR2,
        p_tipo VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_evento DATE,
        p_fk_usuarios_id_usuario NUMBER
    );

    PROCEDURE atualizar_notificacao(
        p_id_notificacao NUMBER,
        p_data_notificacao DATE,
        p_status VARCHAR2,
        p_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER,
        p_fk_densidade_banhistas_id_densidade NUMBER,
        p_fk_eventos_naturais_id_evento NUMBER,
        p_fk_autoridades_id_autoridade NUMBER
    );
END atualizar;
/

CREATE OR REPLACE PACKAGE BODY atualizar AS

    PROCEDURE atualizar_usuario(
        p_id_usuario NUMBER,
        p_nome VARCHAR2,
        p_email VARCHAR2,
        p_senha VARCHAR2,
        p_data_cadastro DATE
    ) IS
    BEGIN
        UPDATE usuarios
        SET nome = p_nome, email = p_email, senha = p_senha, data_cadastro = p_data_cadastro
        WHERE id_usuario = p_id_usuario;
    END atualizar_usuario;

    PROCEDURE atualizar_autoridade(
        p_id_autoridade NUMBER,
        p_nome VARCHAR2,
        p_contato VARCHAR2
    ) IS
    BEGIN
        UPDATE autoridades
        SET nome = p_nome, contato = p_contato
        WHERE id_autoridade = p_id_autoridade;
    END atualizar_autoridade;

    PROCEDURE atualizar_ocorrencia_lixo(
        p_id_ocorrencia_lixo NUMBER,
        p_descricao VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_ocorrencia DATE,
        p_fk_usuarios_id_usuario NUMBER
    ) IS
    BEGIN
        UPDATE ocorrencias_lixo
        SET descricao = p_descricao, latitude = p_latitude, longitude = p_longitude, data_ocorrencia = p_data_ocorrencia, fk_usuarios_id_usuario = p_fk_usuarios_id_usuario
        WHERE id_ocorrencia_lixo = p_id_ocorrencia_lixo;
    END atualizar_ocorrencia_lixo;

    PROCEDURE atualizar_densidade_banhistas(
        p_id_densidade NUMBER,
        p_quantidade_banhistas NUMBER,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_report DATE,
        p_fk_usuarios_id_usuario NUMBER
    ) IS
    BEGIN
        UPDATE densidade_banhistas
        SET quantidade_banhistas = p_quantidade_banhistas, latitude = p_latitude, longitude = p_longitude, data_report = p_data_report, fk_usuarios_id_usuario = p_fk_usuarios_id_usuario
        WHERE id_densidade = p_id_densidade;
    END atualizar_densidade_banhistas;

    PROCEDURE atualizar_evento_natural(
        p_id_evento NUMBER,
        p_descricao VARCHAR2,
        p_tipo VARCHAR2,
        p_latitude NUMBER,
        p_longitude NUMBER,
        p_data_evento DATE,
        p_fk_usuarios_id_usuario NUMBER
    ) IS
    BEGIN
        UPDATE eventos_naturais
        SET descricao = p_descricao, tipo = p_tipo, latitude = p_latitude, longitude = p_longitude, data_evento = p_data_evento, fk_usuarios_id_usuario = p_fk_usuarios_id_usuario
        WHERE id_evento = p_id_evento;
    END atualizar_evento_natural;

    PROCEDURE atualizar_notificacao(
        p_id_notificacao NUMBER,
        p_data_notificacao DATE,
        p_status VARCHAR2,
        p_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER,
        p_fk_densidade_banhistas_id_densidade NUMBER,
        p_fk_eventos_naturais_id_evento NUMBER,
        p_fk_autoridades_id_autoridade NUMBER
    ) IS
    BEGIN
        UPDATE notificacoes
        SET data_notificacao = p_data_notificacao, status = p_status, fk_ocorrencias_lixo_id_ocorrencia_lixo = p_fk_ocorrencias_lixo_id_ocorrencia_lixo, fk_densidade_banhistas_id_densidade = p_fk_densidade_banhistas_id_densidade, fk_eventos_naturais_id_evento = p_fk_eventos_naturais_id_evento, fk_autoridades_id_autoridade = p_fk_autoridades_id_autoridade
        WHERE id_notificacao = p_id_notificacao;
    END atualizar_notificacao;

END atualizar;
/



---TESTE DE ATUALIZAÇÃO




DECLARE
    v_id_usuario NUMBER := 1;
    v_nome VARCHAR2(60) := 'Gustavo Atualizado';
    v_email VARCHAR2(60) := 'gustavo.atualizado@gmail.com';
    v_senha VARCHAR2(30) := 'novasenha123';
    v_data_cadastro DATE := SYSDATE;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela usuarios');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_usuario: ' || v_id_usuario);
    DBMS_OUTPUT.PUT_LINE('nome: ' || v_nome);
    DBMS_OUTPUT.PUT_LINE('email: ' || v_email);
    DBMS_OUTPUT.PUT_LINE('senha: ' || v_senha);
    DBMS_OUTPUT.PUT_LINE('data_cadastro: ' || v_data_cadastro);

    atualizar.atualizar_usuario(v_id_usuario, v_nome, v_email, v_senha, v_data_cadastro);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM usuarios;


DECLARE
    v_id_autoridade NUMBER := 1;
    v_nome VARCHAR2(60) := 'Policia Ambiental Atualizada';
    v_contato VARCHAR2(20) := '8765-4321';
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela autoridades');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_autoridade: ' || v_id_autoridade);
    DBMS_OUTPUT.PUT_LINE('nome: ' || v_nome);
    DBMS_OUTPUT.PUT_LINE('contato: ' || v_contato);

    atualizar.atualizar_autoridade(v_id_autoridade, v_nome, v_contato);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM autoridades;


DECLARE
    v_id_ocorrencia_lixo NUMBER := 1;
    v_descricao VARCHAR2(100) := 'Ocorrência de lixo atualizada';
    v_latitude NUMBER := 35.50;
    v_longitude NUMBER := 121.50;
    v_data_ocorrencia DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela ocorrencias_lixo');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_ocorrencia_lixo: ' || v_id_ocorrencia_lixo);
    DBMS_OUTPUT.PUT_LINE('descricao: ' || v_descricao);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_ocorrencia: ' || v_data_ocorrencia);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    atualizar.atualizar_ocorrencia_lixo(v_id_ocorrencia_lixo, v_descricao, v_latitude, v_longitude, v_data_ocorrencia, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM ocorrencias_lixo;


DECLARE
    v_id_densidade NUMBER := 1;
    v_quantidade_banhistas NUMBER := 200;
    v_latitude NUMBER := 35.50;
    v_longitude NUMBER := 121.50;
    v_data_report DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela densidade_banhistas');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_densidade: ' || v_id_densidade);
    DBMS_OUTPUT.PUT_LINE('quantidade_banhistas: ' || v_quantidade_banhistas);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_report: ' || v_data_report);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    atualizar.atualizar_densidade_banhistas(v_id_densidade, v_quantidade_banhistas, v_latitude, v_longitude, v_data_report, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM densidade_banhistas;


DECLARE
    v_id_evento NUMBER := 1;
    v_descricao VARCHAR2(100) := 'Evento natural atualizado';
    v_tipo VARCHAR2(30) := 'Tempestade';
    v_latitude NUMBER := 35.50;
    v_longitude NUMBER := 121.50;
    v_data_evento DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela eventos_naturais');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_evento: ' || v_id_evento);
    DBMS_OUTPUT.PUT_LINE('descricao: ' || v_descricao);
    DBMS_OUTPUT.PUT_LINE('tipo: ' || v_tipo);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_evento: ' || v_data_evento);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    atualizar.atualizar_evento_natural(v_id_evento, v_descricao, v_tipo, v_latitude, v_longitude, v_data_evento, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM eventos_naturais;



DECLARE
    v_id_notificacao NUMBER := 1;
    v_data_notificacao DATE := SYSDATE;
    v_status VARCHAR2(30) := 'Resolvido atualizado';
    v_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER := 1; -- ID da nova ocorrência de lixo associada
    v_fk_densidade_banhistas_id_densidade NUMBER := NULL; -- Se não houver densidade associada, use NULL
    v_fk_eventos_naturais_id_evento NUMBER := NULL; -- Se não houver evento associado, use NULL
    v_fk_autoridades_id_autoridade NUMBER := NULL; -- Se não houver autoridade associada, use NULL
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela notificacoes');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_notificacao: ' || v_id_notificacao);
    DBMS_OUTPUT.PUT_LINE('data_notificacao: ' || v_data_notificacao);
    DBMS_OUTPUT.PUT_LINE('status: ' || v_status);
    DBMS_OUTPUT.PUT_LINE('fk_ocorrencias_lixo_id_ocorrencia_lixo: ' || v_fk_ocorrencias_lixo_id_ocorrencia_lixo);
    DBMS_OUTPUT.PUT_LINE('fk_densidade_banhistas_id_densidade: ' || v_fk_densidade_banhistas_id_densidade);
    DBMS_OUTPUT.PUT_LINE('fk_eventos_naturais_id_evento: ' || v_fk_eventos_naturais_id_evento);
    DBMS_OUTPUT.PUT_LINE('fk_autoridades_id_autoridade: ' || v_fk_autoridades_id_autoridade);

    atualizar.atualizar_notificacao(
        v_id_notificacao,
        v_data_notificacao,
        v_status,
        v_fk_ocorrencias_lixo_id_ocorrencia_lixo,
        v_fk_densidade_banhistas_id_densidade,
        v_fk_eventos_naturais_id_evento,
        v_fk_autoridades_id_autoridade
    );
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM notificacoes;






---PACOTE DELETAR---




CREATE OR REPLACE PACKAGE deletar AS
    PROCEDURE deletar_usuario(p_id_usuario NUMBER);
    PROCEDURE deletar_autoridade(p_id_autoridade NUMBER);
    PROCEDURE deletar_ocorrencia_lixo(p_id_ocorrencia_lixo NUMBER);
    PROCEDURE deletar_densidade_banhistas(p_id_densidade NUMBER);
    PROCEDURE deletar_evento_natural(p_id_evento NUMBER);
    PROCEDURE deletar_notificacao(p_id_notificacao NUMBER);
END deletar;
/

CREATE OR REPLACE PACKAGE BODY deletar AS
    PROCEDURE deletar_usuario(p_id_usuario NUMBER) IS
    BEGIN
        DELETE FROM usuarios WHERE id_usuario = p_id_usuario;
    END deletar_usuario;

    PROCEDURE deletar_autoridade(p_id_autoridade NUMBER) IS
    BEGIN
        DELETE FROM autoridades WHERE id_autoridade = p_id_autoridade;
    END deletar_autoridade;

    PROCEDURE deletar_ocorrencia_lixo(p_id_ocorrencia_lixo NUMBER) IS
    BEGIN
        DELETE FROM ocorrencias_lixo WHERE id_ocorrencia_lixo = p_id_ocorrencia_lixo;
    END deletar_ocorrencia_lixo;

    PROCEDURE deletar_densidade_banhistas(p_id_densidade NUMBER) IS
    BEGIN
        DELETE FROM densidade_banhistas WHERE id_densidade = p_id_densidade;
    END deletar_densidade_banhistas;

    PROCEDURE deletar_evento_natural(p_id_evento NUMBER) IS
    BEGIN
        DELETE FROM eventos_naturais WHERE id_evento = p_id_evento;
    END deletar_evento_natural;

    PROCEDURE deletar_notificacao(p_id_notificacao NUMBER) IS
    BEGIN
        DELETE FROM notificacoes WHERE id_notificacao = p_id_notificacao;
    END deletar_notificacao;
END deletar;
/


---TESTE PARA DELETAR---


BEGIN
    deletar.deletar_densidade_banhistas(1);
    DBMS_OUTPUT.PUT_LINE('Densidade de banhistas excluída com sucesso');
END;
/
SELECT * FROM densidade_banhistas;

BEGIN
    deletar.deletar_evento_natural(1);
    DBMS_OUTPUT.PUT_LINE('Evento natural excluído com sucesso');
END;
/
SELECT * FROM eventos_naturais;

BEGIN
    deletar.deletar_notificacao(1);
    DBMS_OUTPUT.PUT_LINE('Notificação excluída com sucesso');
END;
/
SELECT * FROM notificacoes;

BEGIN
    deletar.deletar_autoridade(1);
    DBMS_OUTPUT.PUT_LINE('Autoridade excluída com sucesso');
END;
/
SELECT * FROM autoridades;

BEGIN
    deletar.deletar_ocorrencia_lixo(1);
    DBMS_OUTPUT.PUT_LINE('Ocorrência de lixo excluída com sucesso');
END;
/
SELECT * FROM ocorrencias_lixo;

BEGIN
    deletar.deletar_usuario(1);
    DBMS_OUTPUT.PUT_LINE('Usuário excluído com sucesso');
END;
/
SELECT * FROM usuarios;



---RELATORIOS




SET SERVEROUTPUT ON;



--Relatorio de Eventos Naturais
CREATE OR REPLACE PROCEDURE relatorio_eventos_naturais AS
    CURSOR cur_eventos IS
        SELECT 
            u.id_usuario,
            u.nome,
            e.tipo,
            COUNT(e.id_evento) AS num_eventos
        FROM 
            usuarios u
        JOIN 
            eventos_naturais e ON u.id_usuario = e.fk_usuarios_id_usuario
        GROUP BY 
            u.id_usuario, u.nome, e.tipo
        ORDER BY 
            u.id_usuario, e.tipo;

    v_id_usuario usuarios.id_usuario%TYPE;
    v_nome usuarios.nome%TYPE;
    v_tipo eventos_naturais.tipo%TYPE;
    v_num_eventos NUMBER;

BEGIN
    OPEN cur_eventos;
    LOOP
        FETCH cur_eventos INTO v_id_usuario, v_nome, v_tipo, v_num_eventos;
        EXIT WHEN cur_eventos%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('ID: ' || v_id_usuario || ', Nome: ' || v_nome || ', Tipo do Evento: ' || v_tipo || ', Numero de Eventos: ' || v_num_eventos);
    END LOOP;
    CLOSE cur_eventos;
END;
/

EXEC relatorio_eventos_naturais;




--Relatorio de notificações Autoridades
CREATE OR REPLACE PROCEDURE relatorio_notificacoes_autoridades AS
    CURSOR cur_notificacoes IS
        SELECT 
            a.id_autoridade,
            a.nome,
            n.status,
            COUNT(n.id_notificacao) AS num_notificacoes
        FROM 
            autoridades a
        JOIN 
            notificacoes n ON a.id_autoridade = n.fk_autoridades_id_autoridade
        GROUP BY 
            a.id_autoridade, a.nome, n.status
        ORDER BY 
            a.id_autoridade, n.status;

    v_id_autoridade autoridades.id_autoridade%TYPE;
    v_nome autoridades.nome%TYPE;
    v_status notificacoes.status%TYPE;
    v_num_notificacoes NUMBER;

BEGIN
    OPEN cur_notificacoes;
    LOOP
        FETCH cur_notificacoes INTO v_id_autoridade, v_nome, v_status, v_num_notificacoes;
        EXIT WHEN cur_notificacoes%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE('Autoridade ID: ' || v_id_autoridade || ', Nome: ' || v_nome || ', Status: ' || v_status || ', Numero Notificação: ' || v_num_notificacoes);
    END LOOP;
    CLOSE cur_notificacoes;
END;
/

EXEC relatorio_notificacoes_autoridades;




-- trigger para auditar alterações realizadas pelo usuário nas tabelas do banco de dados


DECLARE
    v_id_ocorrencia_lixo NUMBER := 1;
    v_descricao VARCHAR2(100) := 'Ocorrência de lixo atualizada';
    v_latitude NUMBER := 35.50;
    v_longitude NUMBER := 121.50;
    v_data_ocorrencia DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela ocorrencias_lixo');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_ocorrencia_lixo: ' || v_id_ocorrencia_lixo);
    DBMS_OUTPUT.PUT_LINE('descricao: ' || v_descricao);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_ocorrencia: ' || v_data_ocorrencia);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    atualizar.atualizar_ocorrencia_lixo(v_id_ocorrencia_lixo, v_descricao, v_latitude, v_longitude, v_data_ocorrencia, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM ocorrencias_lixo;

DECLARE
    v_id_densidade NUMBER := 1;
    v_quantidade_banhistas NUMBER := 200;
    v_latitude NUMBER := 35.50;
    v_longitude NUMBER := 121.50;
    v_data_report DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela densidade_banhistas');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_densidade: ' || v_id_densidade);
    DBMS_OUTPUT.PUT_LINE('quantidade_banhistas: ' || v_quantidade_banhistas);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_report: ' || v_data_report);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    atualizar.atualizar_densidade_banhistas(v_id_densidade, v_quantidade_banhistas, v_latitude, v_longitude, v_data_report, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM densidade_banhistas;

DECLARE
    v_id_evento NUMBER := 1;
    v_descricao VARCHAR2(100) := 'Evento natural atualizado';
    v_tipo VARCHAR2(30) := 'Tempestade atualizada';
    v_latitude NUMBER := 35.50;
    v_longitude NUMBER := 121.50;
    v_data_evento DATE := SYSDATE;
    v_fk_usuarios_id_usuario NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela eventos_naturais');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_evento: ' || v_id_evento);
    DBMS_OUTPUT.PUT_LINE('descricao: ' || v_descricao);
    DBMS_OUTPUT.PUT_LINE('tipo: ' || v_tipo);
    DBMS_OUTPUT.PUT_LINE('latitude: ' || v_latitude);
    DBMS_OUTPUT.PUT_LINE('longitude: ' || v_longitude);
    DBMS_OUTPUT.PUT_LINE('data_evento: ' || v_data_evento);
    DBMS_OUTPUT.PUT_LINE('fk_usuarios_id_usuario: ' || v_fk_usuarios_id_usuario);

    atualizar.atualizar_evento_natural(v_id_evento, v_descricao, v_tipo, v_latitude, v_longitude, v_data_evento, v_fk_usuarios_id_usuario);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM eventos_naturais;

DECLARE
    v_id_notificacao NUMBER := 1;
    v_data_notificacao DATE := SYSDATE;
    v_status VARCHAR2(30) := 'Concluída';
    v_fk_ocorrencias_lixo_id_ocorrencia_lixo NUMBER := 1;
    v_fk_densidade_banhistas_id_densidade NUMBER := 1;
    v_fk_eventos_naturais_id_evento NUMBER := 1;
    v_fk_autoridades_id_autoridade NUMBER := 1;
BEGIN
    DBMS_OUTPUT.PUT_LINE('Iniciando atualização na tabela notificacoes');
    DBMS_OUTPUT.PUT_LINE('Valores:');
    DBMS_OUTPUT.PUT_LINE('id_notificacao: ' || v_id_notificacao);
    DBMS_OUTPUT.PUT_LINE('data_notificacao: ' || v_data_notificacao);
    DBMS_OUTPUT.PUT_LINE('status: ' || v_status);
    DBMS_OUTPUT.PUT_LINE('fk_ocorrencias_lixo_id_ocorrencia_lixo: ' || v_fk_ocorrencias_lixo_id_ocorrencia_lixo);
    DBMS_OUTPUT.PUT_LINE('fk_densidade_banhistas_id_densidade: ' || v_fk_densidade_banhistas_id_densidade);
    DBMS_OUTPUT.PUT_LINE('fk_eventos_naturais_id_evento: ' || v_fk_eventos_naturais_id_evento);
    DBMS_OUTPUT.PUT_LINE('fk_autoridades_id_autoridade: ' || v_fk_autoridades_id_autoridade);

    atualizar.atualizar_notificacao(v_id_notificacao, v_data_notificacao, v_status, v_fk_ocorrencias_lixo_id_ocorrencia_lixo, v_fk_densidade_banhistas_id_densidade, v_fk_eventos_naturais_id_evento, v_fk_autoridades_id_autoridade);
    
    DBMS_OUTPUT.PUT_LINE('Atualização concluída com sucesso');
END;
/
SELECT * FROM notificacoes;








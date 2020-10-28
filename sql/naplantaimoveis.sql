-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Tempo de geração: 15-Jun-2020 às 17:46
-- Versão do servidor: 10.3.22-MariaDB
-- versão do PHP: 7.3.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `naplantaimoveis`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio`
--

CREATE TABLE `anuncio` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL DEFAULT 0,
  `id_contrato` int(11) NOT NULL DEFAULT 0,
  `id_edificacao` int(11) NOT NULL DEFAULT 0,
  `id_imovel` int(11) NOT NULL DEFAULT 0,
  `id_sub_imovel` int(11) NOT NULL DEFAULT 0,
  `id_situacao` int(11) NOT NULL DEFAULT 0,
  `codigo` varchar(250) NOT NULL DEFAULT '',
  `cep` varchar(250) NOT NULL DEFAULT '',
  `endereco` varchar(250) NOT NULL DEFAULT '',
  `numero` varchar(250) NOT NULL DEFAULT '',
  `complemento` varchar(250) NOT NULL DEFAULT '',
  `bairro` varchar(250) NOT NULL DEFAULT '',
  `cidade` varchar(250) NOT NULL DEFAULT '',
  `estado` varchar(250) NOT NULL DEFAULT '',
  `quartos` int(11) NOT NULL DEFAULT 0,
  `banheiros` int(11) NOT NULL DEFAULT 0,
  `suites` int(11) NOT NULL DEFAULT 0,
  `vagas` int(11) NOT NULL DEFAULT 0,
  `area_util` int(11) NOT NULL DEFAULT 0,
  `area_total` int(11) NOT NULL DEFAULT 0,
  `andar` int(11) NOT NULL DEFAULT 0,
  `pe_direito` int(11) NOT NULL DEFAULT 0,
  `descricao` text NOT NULL DEFAULT '',
  `valor` varchar(250) NOT NULL DEFAULT '0,00',
  `valor_condominio` varchar(250) NOT NULL DEFAULT '0,00',
  `valor_iptu` varchar(250) NOT NULL DEFAULT '0,00',
  `telefone` varchar(250) NOT NULL DEFAULT '',
  `celular` varchar(250) NOT NULL DEFAULT '',
  `email` varchar(250) NOT NULL DEFAULT '',
  `comodidade` varchar(250) NOT NULL DEFAULT '',
  `planta` varchar(250) NOT NULL DEFAULT '',
  `data_anuncio` datetime NOT NULL DEFAULT current_timestamp(),
  `data_aprovacao` datetime NOT NULL DEFAULT current_timestamp(),
  `data_suspenso` datetime NOT NULL DEFAULT current_timestamp(),
  `posicao` int(11) NOT NULL DEFAULT 0,
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio`
--

INSERT INTO `anuncio` (`id`, `id_usuario`, `id_contrato`, `id_edificacao`, `id_imovel`, `id_sub_imovel`, `id_situacao`, `codigo`, `cep`, `endereco`, `numero`, `complemento`, `bairro`, `cidade`, `estado`, `quartos`, `banheiros`, `suites`, `vagas`, `area_util`, `area_total`, `andar`, `pe_direito`, `descricao`, `valor`, `valor_condominio`, `valor_iptu`, `telefone`, `celular`, `email`, `comodidade`, `planta`, `data_anuncio`, `data_aprovacao`, `data_suspenso`, `posicao`, `status`) VALUES
(3, 9, 1, 1, 1, 1, 1, '', '01210000', 'Rua Vitória', '70', '', 'Santa Efigênia', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '00,00', '00,00', '00,00', '(11) 3251-4388', '', '', '0,0', '0,0', '2020-03-22 13:09:32', '2020-03-22 13:09:32', '2020-03-22 13:09:32', 0, 2),
(4, 9, 1, 1, 1, 1, 1, '100', '03168-009', 'Rua dos Trilhos', '10', '', 'Mooca', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '00,00', '00,00', '00,00', '(11) 3255-6311', '', '', '0,0', '0,0', '2020-03-22 13:14:48', '2020-03-22 13:14:48', '2020-03-22 13:14:48', 0, 2),
(5, 9, 1, 1, 1, 1, 1, '100', '04005-010', 'Travessa Umberto Bignardi', '10', '', 'Paraíso', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, 'descrição...', '1200,00', '00,00', '00,00', '(11) 3255-8277', '', '', '0,0', '0,0', '2020-03-22 13:17:40', '2020-03-22 13:17:40', '2020-03-22 13:17:40', 0, 2),
(6, 9, 1, 1, 1, 1, 1, '', '04008-011', 'Rua Joinville', '10', '', 'Vila Mariana', 'São Paulo', 'SP', 2, 1, 0, 0, 100, 250, 0, 230, 'descrição...', '00,00', '00,00', '00,00', '(11) 3399-2084', '(11) 95362-8129', 'lvasconcelos802@gmail.com', '0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,0', '0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0', '2020-03-22 13:21:43', '2020-03-22 13:21:43', '2020-03-22 13:21:43', 1, 2),
(7, 9, 1, 1, 1, 1, 1, '5454545', '01210000', 'Rua Vitória', '111', '', 'Santa Efigênia', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '00,00', '00,00', '00,00', '(11) 3586-9706', '', '', '0,0', '0,0', '2020-03-22 13:30:47', '2020-03-22 13:30:47', '2020-03-22 13:30:47', 0, 2),
(8, 9, 1, 1, 1, 1, 2, '5454545', '04104-021', 'Rua Apeninos', '10', '', 'Paraíso', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '(11) 3782-5101', '', '', '0,0', '0,0', '2020-04-07 21:37:51', '2020-04-07 21:37:51', '2020-04-07 21:37:51', 0, 2),
(9, 9, 1, 1, 1, 1, 1, '', '04547-004', 'Rua Gomes de Carvalho', '70', '', 'Vila Olímpia', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '(11) 3853-4540', '', '', '0,0', '0,0', '2020-04-08 00:36:52', '2020-04-08 00:36:52', '2020-04-08 00:36:52', 0, 2),
(10, 9, 1, 1, 1, 1, 1, '', '04707-000', 'Avenida Roque Petroni Júnior', '70', '', 'Jardim das Acácias', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '(11) 3887-9360', '', '', '0,0', '0,0', '2020-04-08 00:37:42', '2020-04-08 00:37:42', '2020-04-08 00:37:42', 0, 2),
(11, 9, 1, 1, 2, 1, 3, '', '04538-080', 'Avenida Horácio Lafer', '0', '', 'Itaim Bibi', 'São Paulo', 'SP', 1, 1, 0, 0, 52, 52, 0, 0, 'Alugue rápido, sem fiador e com segurança! Agende agora uma visita pelo nosso site buscando pelo código do imóvel.\r\nCÓDIGO DO IMÓVEL: 893057443\r\n\r\nO QuintoAndar é uma startup de tecnologia que criou um jeito diferente de alugar imóveis. Rápido, fácil, online. E melhor: sem fiador, seguro fiança ou depósito caução. Basta ser aprovado na nossa análise de crédito, não precisa correr atrás de nenhuma garantia. Saiba mais em nosso site.', '8.535,00', '318,00', '875,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-08 17:01:31', '2020-04-08 17:01:31', '2020-04-08 17:01:31', 0, 2),
(12, 9, 1, 1, 2, 1, 3, '', '04530-050', 'Rua Itacema', '0', '', 'Itaim Bibi', 'São Paulo', 'SP', 2, 2, 0, 0, 106, 106, 0, 0, 'Alugue rápido, sem fiador e com segurança! Agende agora uma visita pelo nosso site buscando pelo código do imóvel.\r\nCÓDIGO DO IMÓVEL: 893054933', '10000,00', '1580,00', '208,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-10 13:04:26', '2020-04-10 13:04:26', '2020-04-10 13:04:26', 0, 2),
(13, 9, 2, 1, 2, 1, 3, '', '04531-020', 'Rua da Mata', '0', '', 'Itaim Bibi', 'São Paulo', 'SP', 3, 1, 1, 1, 155, 155, 0, 0, 'Apartamento residencial para Venda Itaim Bibi, São Paulo', '0,00', '0,00', '0,00', '00 0000-0000', '', '', '0,10,0', '0,0', '2020-04-10 13:11:56', '2020-04-10 13:11:56', '2020-04-10 13:11:56', 0, 2),
(14, 9, 1, 1, 2, 1, 3, '', '04532-080', 'Rua Jesuíno Arruda', '0', '', 'Itaim Bibi', 'São Paulo', 'SP', 2, 2, 0, 1, 107, 107, 0, 0, 'Alugue rápido, sem fiador e com segurança! Agende agora uma visita pelo nosso site buscando pelo código do imóvel.\r\nCÓDIGO DO IMÓVEL: 893051152\r\n\r\nO QuintoAndar é uma startup de tecnologia que criou um jeito diferente de alugar imóveis. Rápido, fácil, online. E melhor: sem fiador, seguro fiança ou depósito caução. Basta ser aprovado na nossa análise de crédito, não precisa correr atrás de nenhuma garantia. Saiba mais em nosso site.', '4.860,00', '0,00', '1.430,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-10 13:22:58', '2020-04-10 13:22:58', '2020-04-10 13:22:58', 0, 2),
(15, 9, 1, 1, 1, 3, 3, '', '04531-020', 'Rua da Mata', '70', '', 'Itaim Bibi', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-15 12:37:37', '2020-04-15 12:37:37', '2020-04-15 12:37:37', 0, 2),
(16, 9, 1, 1, 1, 1, 3, '', '04531-020', 'Rua da Mata', '70', '', 'Itaim Bibi', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '00 0000-0000', '', '', '0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,0', '0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0', '2020-04-21 13:34:00', '2020-04-21 13:34:00', '2020-04-21 13:34:00', 0, 2),
(17, 9, 2, 1, 1, 3, 3, '', '0000-000', '', '0', '', '', '', '', 3, 4, 0, 4, 180, 0, 0, 0, '', '680.000,00', '0,00', '0,00', '(13) 3034-3838', '', '', '0,0', '0,0', '2020-04-21 16:03:05', '2020-04-21 16:03:05', '2020-04-21 16:03:05', 0, 2),
(18, 9, 1, 1, 1, 3, 3, '', '04531-020', 'Rua da Mata', '70', '', 'Itaim Bibi', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '00 0000-0000', '', '', '0,1,3,4,6,8,9,0', '0,1,3,5,7,0', '2020-04-21 20:14:20', '2020-04-21 20:14:20', '2020-04-21 20:14:20', 0, 2),
(19, 9, 1, 2, 1, 3, 3, '', '04014-010', 'Avenida Conselheiro Rodrigues Alves', '0', '', 'Vila Mariana', 'São Paulo', 'SP', 0, 0, 0, 0, 315, 279, 0, 0, 'Prédio em Vila Mariana, São Paulo/SP de 279m² para locação R$ 12.000,00/mês.', '12.000,00', '0,00', '0,00', '00 0000-0000', '', '', '0,1,0', '0,0', '2020-04-22 00:07:11', '2020-04-22 00:07:11', '2020-04-22 00:07:11', 0, 1),
(20, 9, 1, 2, 10, 1, 3, '', '37701-039', 'Rua Barão do Campo Místico', '0', '', 'Centro', 'Poços de Caldas', 'MG', 0, 2, 0, 4, 150, 327, 0, 0, 'Imóvel Comercial com duas salas, terreno com 327,00 m, 13 m para a Rua Barão do Campo Místico, 15 m para o prolongamento da Avenida Irradiação ( a ser executada ), uma sala com 50 m e outra com 100 m, banheiros amplos, muitas tomadas, acabamento de primeira, telhado termoacustico, recuo frontal com estacionamento, entradas de luz separadas, possibilidade de construção de outras salas ou moradia nos fundos do terreno voltado para a futura Av Irradiação, possibilidade de faturamento com aluguel entre R$ 4.000,00 a R$ 5.000,00 pois trata-se de uma região de Poços de Caldas com muito movimento e poucos imóveis neste padrão.', '750.000,00', '0,00', '0,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-22 16:57:18', '2020-04-22 16:57:18', '2020-04-22 16:57:18', 0, 1),
(21, 9, 1, 2, 10, 1, 3, '', '13070-000', 'Avenida Andrade Neves', '0', '', 'Jardim Chapadão', 'Campinas', 'SP', 3, 0, 1, 4, 465, 282, 0, 0, 'Imóvel com estacionamento para 4 veículos, ampla recepção, sala ampla, + 3 dormitórios sendo 1 suite, cozinha, banheiro social, mais uma edicula nos fundos com 2 dormitórios.Estuda carência no aluguel para reforma do imóvel caso necessário.', '8.000,00', '0,00', '0,00', '00 0000-0000', '', '', '0,15,0', '0,2,0', '2020-04-22 17:15:51', '2020-04-22 17:15:51', '2020-04-22 17:15:51', 0, 1),
(22, 9, 1, 2, 2, 2, 3, '', '04551-090', 'Alameda Raja Gabaglia', '0', '', 'Vila Olímpia', 'São Paulo', 'SP', 0, 5, 0, 4, 266, 266, 0, 0, 'Imóvel Comercial em Vila Olímpia, São Paulo/SP de 266m² para locação R$ 12.000,00/mes e condomínio de R$ 4.985,00 com Elevador. Entre em contato e agende já uma visita com um de nossos corretores!', '12.000,00', '4.985,00', '2.200,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-22 17:21:18', '2020-04-22 17:21:18', '2020-04-22 17:21:18', 0, 1),
(23, 9, 1, 2, 10, 2, 3, '', '05212-060', 'Rua Estados Unidos', '0', '', 'Jardim da Conquista (Zona Oeste)', 'São Paulo', 'SP', 0, 1, 0, 1, 46, 46, 0, 0, 'Entre em contato e agende já uma visita com um de nossos corretores!', '3190,00', '784,00', '450,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-24 16:23:54', '2020-04-24 16:23:54', '2020-04-24 16:23:54', 0, 1),
(24, 9, 1, 1, 2, 2, 3, '', '01423-000', 'Rua José Maria Lisboa', '0', '', 'Jardim Paulista', 'São Paulo', 'SP', 2, 1, 0, 1, 88, 0, 0, 0, '', '2.500,00', '1300,00', '200,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-24 16:30:31', '2020-04-24 16:30:31', '2020-04-24 16:30:31', 0, 1),
(25, 9, 1, 1, 2, 1, 3, '', '01420-000', 'Alameda Jaú', '0', '', 'Jardim Paulista', 'São Paulo', 'SP', 2, 2, 0, 2, 68, 68, 0, 0, '', '2.300,00', '2600,00', '0,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-24 16:34:24', '2020-04-24 16:34:24', '2020-04-24 16:34:24', 0, 1),
(26, 9, 1, 1, 2, 2, 3, '', '01423-000', 'Rua José Maria Lisboa', '0', '', 'Jardim Paulista', 'São Paulo', 'SP', 3, 2, 1, 1, 180, 200, 3, 0, 'APTO C/ TACOS NOVOS, TODO REFORMADO, PARTE ELÉTRICA NOVA, COM ARMS.LIVING PARA TRÊS AMBIENTES,3 DORMTS COM UMA SUITE E UMA VAGA DE GARAGEM, DEPENDÊNCIA DE EMPREGADA.LAZER COM BRINQUEDOTECA,QUADRA E LOCAL PARA CAMINHADA, ÁREA VERDE', '5.000,00', '2000,00', '400,00', '00 0000-0000', '', '', '0,0', '0,0', '2020-04-24 16:40:05', '2020-04-24 16:40:05', '2020-04-24 16:40:05', 0, 1),
(27, 9, 1, 1, 1, 1, 3, '', '01210000', 'Rua Vitória', '70', '', 'Santa Efigênia', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '3432322525', '', '', '0,0', '0,0', '2020-05-09 11:56:52', '2020-05-09 11:56:52', '2020-05-09 11:56:52', 0, 2),
(28, 9, 1, 1, 1, 1, 3, '', '01210000', 'Rua Vitória', '70', '', 'Santa Efigênia', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '3436363232', '', '', '0,0', '0,0', '2020-06-15 12:45:44', '2020-06-15 12:45:44', '2020-06-15 12:45:44', 0, 2),
(29, 9, 1, 1, 1, 1, 3, '', '01210000', 'Rua Vitória', '70', '', 'Santa Efigênia', 'São Paulo', 'SP', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '3436363232', '', '', '0,0', '0,0', '2020-06-15 12:52:22', '2020-06-15 12:52:22', '2020-06-15 12:52:22', 0, 2),
(30, 9, 0, 0, 0, 0, 0, '', '', '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, '', '0,00', '0,00', '0,00', '', '', '', '', '', '2020-06-15 14:10:19', '2020-06-15 14:10:19', '2020-06-15 14:10:19', 0, 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_comodidade`
--

CREATE TABLE `anuncio_comodidade` (
  `id` int(11) NOT NULL,
  `comodidade` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_comodidade`
--

INSERT INTO `anuncio_comodidade` (`id`, `comodidade`, `posicao`, `status`) VALUES
(1, 'Internet', 1, 1),
(2, 'Ar-condicionado', 2, 1),
(3, 'Brinquedoteca', 3, 1),
(4, 'Elevador', 4, 1),
(5, 'Centro comercial', 5, 1),
(6, 'Aquecedor', 6, 1),
(7, 'Quadra de tênis', 7, 1),
(8, 'Lareira', 8, 1),
(9, 'Cisterna', 9, 1),
(10, 'Vagas para visitantes\r\n', 10, 1),
(11, 'Academia', 11, 1),
(12, 'Jacuzzi', 12, 1),
(13, 'Lavanderia coletiva', 13, 1),
(14, 'Piscina', 14, 1),
(15, 'Recepção', 15, 1),
(16, 'Salão de festas', 16, 1),
(17, 'Segurança', 17, 1),
(18, 'Acesso para deficientes', 18, 1),
(19, 'TV a Cabo', 19, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_contrato`
--

CREATE TABLE `anuncio_contrato` (
  `id` int(11) NOT NULL,
  `contrato` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_contrato`
--

INSERT INTO `anuncio_contrato` (`id`, `contrato`, `posicao`, `status`) VALUES
(1, 'Alugar', 1, 1),
(2, 'Vender', 2, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_edificacao`
--

CREATE TABLE `anuncio_edificacao` (
  `id` int(11) NOT NULL,
  `edificacao` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_edificacao`
--

INSERT INTO `anuncio_edificacao` (`id`, `edificacao`, `posicao`, `status`) VALUES
(1, 'Residencial', 1, 1),
(2, 'Comercial', 2, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_foto`
--

CREATE TABLE `anuncio_foto` (
  `id` int(11) NOT NULL,
  `id_anuncio` int(11) NOT NULL DEFAULT 0,
  `titulo` varchar(250) NOT NULL DEFAULT '',
  `foto` varchar(250) NOT NULL DEFAULT '',
  `posicao` int(11) NOT NULL DEFAULT 0,
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_foto`
--

INSERT INTO `anuncio_foto` (`id`, `id_anuncio`, `titulo`, `foto`, `posicao`, `status`) VALUES
(1, 5, 'Casa - Alugar - Padrão - Paraíso - São Paulo - SP', 'casa-alugar-padrao-paraiso-sao-paulo-sp-5-22032020132014.jpg', 0, 0),
(2, 6, 'Casa - Alugar - Padrão - Vila Mariana - São Paulo - SP', 'casa-alugar-padrao-vila-mariana-sao-paulo-sp-6-22032020132215.jpg', 0, 0),
(3, 6, 'Casa - Alugar - Padrão - Vila Mariana - São Paulo - SP', 'casa-alugar-padrao-vila-mariana-sao-paulo-sp-6-22032020132238.jpg', 0, 0),
(4, 6, 'Casa - Alugar - Padrão - Vila Mariana - São Paulo - SP', 'casa-alugar-padrao-vila-mariana-sao-paulo-sp-6-22032020132259.jpg', 0, 0),
(5, 6, 'Casa - Alugar - Padrão - Vila Mariana - São Paulo - SP', 'casa-alugar-padrao-vila-mariana-sao-paulo-sp-6-23032020203011.jpg', 0, 1),
(6, 6, 'Casa - Alugar - Padrão - Vila Mariana - São Paulo - SP', 'casa-alugar-padrao-vila-mariana-sao-paulo-sp-6-23032020203028.jpg', 0, 1),
(7, 5, 'Casa - Alugar - Padrão - Paraíso - São Paulo - SP', 'casa-alugar-padrao-paraiso-sao-paulo-sp-5-23032020203259.jpg', 0, 1),
(8, 10, 'Residencial - Alugar - Casa - Padrão - Jardim das Acácias - São Paulo - SP', 'residencial-alugar-casa-padrao-jardim-das-acacias-sao-paulo-sp-10-09042020135125.jpg', 0, 0),
(9, 9, 'Imóvel - Residencial - Alugar - Casa - Padrão - Vila Olímpia - São Paulo - SP', 'imovel-residencial-alugar-casa-padrao-vila-olimpia-sao-paulo-sp-9-09042020135518.jpg', 0, 0),
(10, 10, 'Imóvel - Residencial - Alugar - Casa - Padrão - Jardim das Acácias - São Paulo - SP', 'imovel-residencial-alugar-casa-padrao-jardim-das-acacias-sao-paulo-sp-10-09042020163007.jpg', 0, 1),
(11, 9, 'Imóvel - Residencial - Alugar - Casa - Padrão - Vila Olímpia - São Paulo - SP', 'imovel-residencial-alugar-casa-padrao-vila-olimpia-sao-paulo-sp-9-09042020163038.jpg', 0, 1),
(12, 11, 'Imóvel - Residencial - Alugar - Apartamento - Padrão - Itaim Bibi - São Paulo - SP', 'imovel-residencial-alugar-apartamento-padrao-itaim-bibi-sao-paulo-sp-11-10042020122302.jpg', 0, 1),
(13, 12, 'Imóvel - Residencial - Alugar - Apartamento - Padrão - Itaim Bibi - São Paulo - SP', 'imovel-residencial-alugar-apartamento-padrao-itaim-bibi-sao-paulo-sp-12-10042020130756.jpg', 0, 1),
(14, 13, 'Imóvel - Residencial - Vender - Apartamento - Padrão - Itaim Bibi - São Paulo - SP', 'imovel-residencial-vender-apartamento-padrao-itaim-bibi-sao-paulo-sp-13-10042020131750.jpg', 0, 1),
(15, 14, 'Imóvel - Residencial - Alugar - Apartamento - Padrão - Itaim Bibi - São Paulo - SP', 'imovel-residencial-alugar-apartamento-padrao-itaim-bibi-sao-paulo-sp-14-10042020132858.jpg', 0, 1),
(16, 16, 'Casa Padrão para Alugar - Itaim Bibi - São Paulo - SP', 'casa-padrao-para-alugar-itaim-bibi-sao-paulo-sp-16-21042020134116.jpg', 0, 1),
(17, 17, 'Casa Sobrado para Vender -  -  - ', 'casa-sobrado-para-vender----17-21042020201552.jpg', 0, 0),
(18, 19, 'Casa Sobrado para Alugar - Vila Mariana - São Paulo - SP', 'casa-sobrado-para-alugar-vila-mariana-sao-paulo-sp-19-22042020165518.jpg', 0, 1),
(19, 19, 'Casa Sobrado para Alugar - Vila Mariana - São Paulo - SP', 'casa-sobrado-para-alugar-vila-mariana-sao-paulo-sp-19-22042020165537.jpg', 0, 1),
(20, 19, 'Casa Sobrado para Alugar - Vila Mariana - São Paulo - SP', 'casa-sobrado-para-alugar-vila-mariana-sao-paulo-sp-19-22042020165545.jpg', 0, 1),
(21, 20, 'Sala Padrão para Alugar - Centro - Poços de Caldas - MG', 'sala-padrao-para-alugar-centro-pocos-de-caldas-mg-20-22042020171315.jpg', 0, 1),
(22, 20, 'Sala Padrão para Alugar - Centro - Poços de Caldas - MG', 'sala-padrao-para-alugar-centro-pocos-de-caldas-mg-20-22042020171323.jpg', 0, 1),
(23, 20, 'Sala Padrão para Alugar - Centro - Poços de Caldas - MG', 'sala-padrao-para-alugar-centro-pocos-de-caldas-mg-20-22042020171333.jpg', 0, 1),
(24, 20, 'Sala Padrão para Alugar - Centro - Poços de Caldas - MG', 'sala-padrao-para-alugar-centro-pocos-de-caldas-mg-20-22042020171341.jpg', 0, 1),
(25, 21, 'Sala Padrão para Alugar - Jardim Chapadão - Campinas - SP', 'sala-padrao-para-alugar-jardim-chapadao-campinas-sp-21-22042020171937.jpg', 0, 1),
(26, 21, 'Sala Padrão para Alugar - Jardim Chapadão - Campinas - SP', 'sala-padrao-para-alugar-jardim-chapadao-campinas-sp-21-22042020171946.jpg', 0, 1),
(27, 22, 'Apartamento Condomínio para Alugar - Vila Olímpia - São Paulo - SP', 'apartamento-condominio-para-alugar-vila-olimpia-sao-paulo-sp-22-22042020172621.jpg', 0, 1),
(28, 22, 'Apartamento Condomínio para Alugar - Vila Olímpia - São Paulo - SP', 'apartamento-condominio-para-alugar-vila-olimpia-sao-paulo-sp-22-22042020172628.jpg', 0, 1),
(29, 22, 'Apartamento Condomínio para Alugar - Vila Olímpia - São Paulo - SP', 'apartamento-condominio-para-alugar-vila-olimpia-sao-paulo-sp-22-22042020172636.jpg', 0, 1),
(30, 22, 'Apartamento Condomínio para Alugar - Vila Olímpia - São Paulo - SP', 'apartamento-condominio-para-alugar-vila-olimpia-sao-paulo-sp-22-22042020172646.jpg', 0, 1),
(31, 22, 'Apartamento Condomínio para Alugar - Vila Olímpia - São Paulo - SP', 'apartamento-condominio-para-alugar-vila-olimpia-sao-paulo-sp-22-22042020172656.jpg', 0, 1),
(32, 23, 'Sala Condomínio para Alugar - Jardim da Conquista (Zona Oeste) - São Paulo - SP', 'sala-condominio-para-alugar-jardim-da-conquista-(zona-oeste)-sao-paulo-sp-23-24042020162842.jpg', 0, 1),
(33, 23, 'Sala Condomínio para Alugar - Jardim da Conquista (Zona Oeste) - São Paulo - SP', 'sala-condominio-para-alugar-jardim-da-conquista-(zona-oeste)-sao-paulo-sp-23-24042020162850.jpg', 0, 1),
(34, 23, 'Sala Condomínio para Alugar - Jardim da Conquista (Zona Oeste) - São Paulo - SP', 'sala-condominio-para-alugar-jardim-da-conquista-(zona-oeste)-sao-paulo-sp-23-24042020162859.jpg', 0, 1),
(35, 23, 'Sala Condomínio para Alugar - Jardim da Conquista (Zona Oeste) - São Paulo - SP', 'sala-condominio-para-alugar-jardim-da-conquista-(zona-oeste)-sao-paulo-sp-23-24042020162907.jpg', 0, 1),
(36, 24, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-24-24042020163335.jpg', 0, 1),
(37, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-24042020163815.jpg', 0, 0),
(38, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-24042020163824.jpg', 0, 0),
(39, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-24042020163832.jpg', 0, 0),
(40, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-24042020163840.jpg', 0, 0),
(41, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-24042020163851.jpg', 0, 0),
(42, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-24042020164522.jpg', 0, 0),
(43, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-24042020164530.jpg', 0, 0),
(44, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-24042020164539.jpg', 0, 0),
(45, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-24042020164547.jpg', 0, 0),
(46, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-24042020164559.jpg', 0, 0),
(47, 27, 'Casa Padrão para Alugar - Santa Efigênia - São Paulo - SP', 'casa-padrao-para-alugar-santa-efigenia-sao-paulo-sp-27-15062020124355.png', 0, 1),
(48, 28, 'Casa Padrão para Alugar - Santa Efigênia - São Paulo - SP', 'casa-padrao-para-alugar-santa-efigenia-sao-paulo-sp-28-15062020124642.png', 0, 1),
(49, 29, 'Casa Padrão para Alugar - Santa Efigênia - São Paulo - SP', 'casa-padrao-para-alugar-santa-efigenia-sao-paulo-sp-29-15062020125302.jpg', 0, 1),
(50, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164451.jpg', 0, 0),
(51, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164623.jpg', 0, 0),
(52, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164633.jpg', 0, 0),
(53, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164705.jpg', 0, 1),
(54, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164715.jpg', 0, 1),
(55, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164725.jpg', 0, 1),
(56, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164736.jpg', 0, 1),
(57, 26, 'Apartamento Condomínio para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-condominio-para-alugar-jardim-paulista-sao-paulo-sp-26-15062020164749.jpg', 0, 1),
(58, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-15062020164916.jpg', 0, 1),
(59, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-15062020164929.jpg', 0, 1),
(60, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-15062020164941.jpg', 0, 1),
(61, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-15062020164955.jpg', 0, 1),
(62, 25, 'Apartamento Padrão para Alugar - Jardim Paulista - São Paulo - SP', 'apartamento-padrao-para-alugar-jardim-paulista-sao-paulo-sp-25-15062020165014.jpg', 0, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_imovel`
--

CREATE TABLE `anuncio_imovel` (
  `id` int(11) NOT NULL,
  `imovel` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_imovel`
--

INSERT INTO `anuncio_imovel` (`id`, `imovel`, `posicao`, `status`) VALUES
(1, 'Casa', 1, 1),
(2, 'Apartamento', 2, 1),
(3, 'Kitnet', 3, 1),
(4, 'Pousada', 4, 1),
(5, 'Flat', 5, 1),
(6, 'Hotel', 6, 1),
(7, 'Studio', 7, 1),
(8, 'JK', 8, 1),
(9, 'Loft', 9, 1),
(10, 'Sala', 4, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_planta`
--

CREATE TABLE `anuncio_planta` (
  `id` int(11) NOT NULL,
  `planta` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_planta`
--

INSERT INTO `anuncio_planta` (`id`, `planta`, `posicao`, `status`) VALUES
(1, 'Varanda', 1, 1),
(2, 'Cozinha', 2, 1),
(3, 'Sala de jantar', 3, 1),
(4, 'Quarto de empregada\r\n', 4, 1),
(5, 'Suíte', 5, 1),
(6, 'Home office', 6, 1),
(7, 'Jardim', 7, 1),
(8, 'Sala de estar', 8, 1),
(9, 'Pátio', 9, 1),
(10, 'Armários embutidos', 10, 1),
(11, 'Salão de jogos', 11, 1),
(12, 'Terraço com jardim', 12, 1),
(13, 'Terraço', 13, 1),
(14, 'Lavabo', 14, 1),
(15, 'Closet', 15, 1),
(16, 'Piscina', 16, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_situacao`
--

CREATE TABLE `anuncio_situacao` (
  `id` int(11) NOT NULL,
  `situacao` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL DEFAULT 0,
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_situacao`
--

INSERT INTO `anuncio_situacao` (`id`, `situacao`, `posicao`, `status`) VALUES
(1, 'Em obras', 2, 1),
(2, 'Na planta', 3, 1),
(3, 'Pronto para morar', 1, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `anuncio_sub_imovel`
--

CREATE TABLE `anuncio_sub_imovel` (
  `id` int(11) NOT NULL,
  `sub_imovel` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `anuncio_sub_imovel`
--

INSERT INTO `anuncio_sub_imovel` (`id`, `sub_imovel`, `posicao`, `status`) VALUES
(1, 'Padrão', 1, 1),
(2, 'Condomínio', 2, 1),
(3, 'Sobrado', 3, 1),
(4, 'Térrea', 4, 1),
(5, 'Vila', 5, 1),
(6, 'Rua Particular\r\n', 6, 1),
(7, 'Duplex', 7, 1),
(8, 'Triplex', 8, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `newsletter`
--

CREATE TABLE `newsletter` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL DEFAULT 0,
  `id_anuncio` varchar(250) NOT NULL DEFAULT '',
  `id_email` varchar(250) NOT NULL DEFAULT '',
  `assunto` varchar(250) NOT NULL DEFAULT '',
  `mensagem` varchar(250) NOT NULL DEFAULT '',
  `data` datetime NOT NULL DEFAULT current_timestamp(),
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `newsletter`
--

INSERT INTO `newsletter` (`id`, `id_usuario`, `id_anuncio`, `id_email`, `assunto`, `mensagem`, `data`, `status`) VALUES
(39, 9, '0,26,25,0', '0,44,43,41,0', 'Anunciar Imóveis', 'Anuncie seus imóvéis grátis. CRM com portal de anúncios e envio de newsletter.', '2020-06-09 10:59:48', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `newsletter_email`
--

CREATE TABLE `newsletter_email` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL DEFAULT 0,
  `grupo` varchar(250) NOT NULL DEFAULT '',
  `nome` varchar(250) NOT NULL DEFAULT '',
  `email` varchar(250) NOT NULL DEFAULT '',
  `data` datetime NOT NULL DEFAULT current_timestamp(),
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `newsletter_email`
--

INSERT INTO `newsletter_email` (`id`, `id_usuario`, `grupo`, `nome`, `email`, `data`, `status`) VALUES
(1, 9, '', '', 'lucas1@gmail.com', '2020-05-16 09:55:21', 0),
(2, 9, 'grupo 1', 'lucas 2', 'lucas2@gmail.com', '2020-05-16 09:55:21', 0),
(3, 9, 'grupo 2', 'lucas 3', 'lucas3@gmail.com', '2020-05-16 09:56:43', 0),
(4, 9, 'grupo 4', 'lucas 4', 'lucas4@gmail.com', '2020-05-16 09:56:43', 0),
(7, 9, '', '', 'ana1@gmail.com', '2020-05-16 10:35:11', 0),
(8, 9, '', '', 'marcos1@gmail.com', '2020-05-16 10:35:40', 0),
(9, 9, '', '', 'ana2@gmail.com', '2020-05-16 10:36:19', 0),
(10, 9, 'grupo', 'nome', 'email', '2020-05-18 11:39:11', 0),
(11, 9, 'grupo 2', 'nome 2', 'email 2', '2020-05-18 11:44:01', 0),
(12, 9, '', '', 'dfdf', '2020-05-18 12:02:55', 0),
(13, 9, '', '', 'dfdf', '2020-05-18 12:03:01', 0),
(14, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:04:31', 0),
(15, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:23:56', 0),
(16, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:40:32', 0),
(17, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:40:37', 0),
(18, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:40:44', 0),
(19, 9, 'grupo', 'nome', 'lucas@gmail.com', '2020-05-18 12:42:45', 0),
(20, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:46:35', 0),
(21, 9, '', '', 'lucas@gmail.com', '2020-05-18 12:46:42', 0),
(22, 9, '', '', 'lucas@gmail.com', '2020-05-18 13:01:11', 0),
(23, 9, '', '', 'lucas@gmail.com', '2020-05-18 13:01:26', 0),
(24, 9, '', '', 'lucas@gmail.com', '2020-05-18 14:01:42', 0),
(25, 9, '', '', 'lucas@gmail.com', '2020-05-18 14:25:07', 0),
(26, 9, 'teste', 'nome', 'lucas3333@gmail.com', '2020-05-19 09:45:05', 0),
(27, 9, 'teste', 'nome', 'lucasbbbb@gmail.com', '2020-05-19 09:47:06', 0),
(28, 9, 'grupo 3', 'nome 3', 'lucas547@gmail.com', '2020-05-19 09:50:31', 0),
(29, 9, '', '', 'lucas555@gmail.com', '2020-05-20 11:08:44', 0),
(30, 9, 'teste', 'nome', 'lucafrfrs@gmail.com', '2020-05-22 14:33:31', 0),
(31, 9, 'teste', 'nome', 'lucasrfrr@gmail.com', '2020-05-22 19:40:15', 0),
(32, 9, 'teste', 'nome', 'lucasrfrrff@gmail.com', '2020-05-22 19:51:48', 0),
(33, 9, 'grupo 3', 'nome 3', 'lucas5525@gmail.com', '2020-05-27 10:01:48', 0),
(34, 9, 'grupo 3', 'nome', 'lucas111@gmail.com', '2020-05-27 10:02:08', 0),
(35, 9, 'teste', 'nome', 'lucasfdfdfd@gmail.com', '2020-05-27 12:05:39', 0),
(36, 9, 'teste', 'nome', 'testeeee@gmail.comff', '2020-05-27 12:05:54', 0),
(37, 9, 'teste', 'nome', 'lucaswsws@gmail.com', '2020-05-27 12:10:53', 0),
(38, 9, 'teste', 'nome', 'lucasqwqwq@gmail.com', '2020-05-27 12:14:13', 0),
(39, 9, 'teste', 'nome', 'lucas23232@gmail.com', '2020-05-27 12:42:10', 0),
(40, 9, 'ww', 'ww', 'lucasdrty@gmail.com', '2020-05-27 12:42:46', 0),
(41, 9, 'grupo 1', 'Lucas', 'lvasconcelos802@gmail.com', '2020-06-12 12:20:22', 1),
(42, 9, '', 'na planta imóveis', 'naplantaimoveisoficial@gmail.com', '2020-06-15 15:44:40', 0),
(43, 9, '', 'Erica', 'ericabocchi@hotmail.com', '2020-06-15 16:58:37', 1),
(44, 9, '', 'Bahamas Imobiliária', 'bahamasimobiliaria@gmail.com', '2020-06-15 16:59:09', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `newsletter_relatorio`
--

CREATE TABLE `newsletter_relatorio` (
  `id` int(11) NOT NULL,
  `id_newsletter` int(11) NOT NULL DEFAULT 0,
  `id_email` int(11) NOT NULL DEFAULT 0,
  `click` int(11) NOT NULL DEFAULT 0,
  `data` datetime NOT NULL DEFAULT current_timestamp(),
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `id` int(11) NOT NULL,
  `id_nivel` int(11) NOT NULL,
  `id_pessoa` int(11) NOT NULL,
  `logo` varchar(250) NOT NULL,
  `empresa` varchar(250) NOT NULL,
  `cnpj` varchar(250) NOT NULL,
  `nome` varchar(250) NOT NULL,
  `cpf` varchar(250) NOT NULL,
  `email` varchar(250) NOT NULL,
  `senha` varchar(250) NOT NULL,
  `telefone` varchar(250) NOT NULL,
  `celular` varchar(250) NOT NULL,
  `site` varchar(250) NOT NULL,
  `creci` varchar(250) NOT NULL,
  `data` datetime NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`id`, `id_nivel`, `id_pessoa`, `logo`, `empresa`, `cnpj`, `nome`, `cpf`, `email`, `senha`, `telefone`, `celular`, `site`, `creci`, `data`, `status`) VALUES
(9, 1, 1, '9.jpg', 'Na Planta Imóveis', '00000000', 'Lucas Vasconcelos', '00000000', 'Y29tZXJjaWFsQG5hcGxhbnRhaW1vdmVpcy5jb20uYnI=', 'ZWxlZmFudGUyMDIw', '(00) 0000-0000', '(00) 0000-0000', 'www.naplantaimoveis.com.br', '00000000', '2020-03-21 17:50:51', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario_nivel`
--

CREATE TABLE `usuario_nivel` (
  `id` int(11) NOT NULL,
  `nivel` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuario_nivel`
--

INSERT INTO `usuario_nivel` (`id`, `nivel`, `posicao`, `status`) VALUES
(1, 'CRM\r\n', 1, 1),
(2, 'Usuário', 2, 1),
(3, 'Corretor', 3, 1),
(4, 'Imobiliária', 4, 1),
(5, 'Proprietário', 5, 1),
(6, 'Incorporadora', 6, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario_pessoa`
--

CREATE TABLE `usuario_pessoa` (
  `id` int(11) NOT NULL,
  `pessoa` varchar(250) NOT NULL,
  `posicao` int(11) NOT NULL,
  `status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuario_pessoa`
--

INSERT INTO `usuario_pessoa` (`id`, `pessoa`, `posicao`, `status`) VALUES
(1, 'Física', 1, 1),
(2, 'Jurídica', 2, 1);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `anuncio`
--
ALTER TABLE `anuncio`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_comodidade`
--
ALTER TABLE `anuncio_comodidade`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_contrato`
--
ALTER TABLE `anuncio_contrato`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_edificacao`
--
ALTER TABLE `anuncio_edificacao`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_foto`
--
ALTER TABLE `anuncio_foto`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_imovel`
--
ALTER TABLE `anuncio_imovel`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_planta`
--
ALTER TABLE `anuncio_planta`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_situacao`
--
ALTER TABLE `anuncio_situacao`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `anuncio_sub_imovel`
--
ALTER TABLE `anuncio_sub_imovel`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `newsletter`
--
ALTER TABLE `newsletter`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `newsletter_email`
--
ALTER TABLE `newsletter_email`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `newsletter_relatorio`
--
ALTER TABLE `newsletter_relatorio`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `usuario_nivel`
--
ALTER TABLE `usuario_nivel`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `usuario_pessoa`
--
ALTER TABLE `usuario_pessoa`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `anuncio`
--
ALTER TABLE `anuncio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT de tabela `anuncio_comodidade`
--
ALTER TABLE `anuncio_comodidade`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de tabela `anuncio_contrato`
--
ALTER TABLE `anuncio_contrato`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `anuncio_edificacao`
--
ALTER TABLE `anuncio_edificacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `anuncio_foto`
--
ALTER TABLE `anuncio_foto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT de tabela `anuncio_imovel`
--
ALTER TABLE `anuncio_imovel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `anuncio_planta`
--
ALTER TABLE `anuncio_planta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de tabela `anuncio_situacao`
--
ALTER TABLE `anuncio_situacao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `anuncio_sub_imovel`
--
ALTER TABLE `anuncio_sub_imovel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de tabela `newsletter`
--
ALTER TABLE `newsletter`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT de tabela `newsletter_email`
--
ALTER TABLE `newsletter_email`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT de tabela `newsletter_relatorio`
--
ALTER TABLE `newsletter_relatorio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `usuario_nivel`
--
ALTER TABLE `usuario_nivel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `usuario_pessoa`
--
ALTER TABLE `usuario_pessoa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

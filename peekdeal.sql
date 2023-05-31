-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Mag 31, 2023 alle 09:30
-- Versione del server: 10.4.27-MariaDB
-- Versione PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `peekdeal`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `article`
--

CREATE TABLE `article` (
  `id_articolo` int(11) NOT NULL,
  `id_spesa` int(11) NOT NULL,
  `articolo` varchar(255) NOT NULL,
  `quantità` int(11) NOT NULL,
  `acquistato` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `article`
--

INSERT INTO `article` (`id_articolo`, `id_spesa`, `articolo`, `quantità`, `acquistato`) VALUES
(1, 1, 'Latte', 1, 0),
(2, 1, 'Uova', 2, 1),
(3, 2, 'pane', 1, 0),
(4, 1, 'Pane', 2, 1),
(5, 1, 'Latte', 3, 1),
(6, 1, 'Formaggio', 1, 0),
(7, 2, 'Riso', 1, 1),
(8, 2, 'Pasta', 4, 1),
(9, 2, 'Sugo', 2, 1),
(10, 3, 'Frutta', 5, 0),
(11, 3, 'Verdura', 3, 0),
(12, 3, 'Carne', 2, 1),
(13, 1, 'Uova', 1, 1),
(14, 1, 'Burro', 2, 0),
(15, 2, 'Biscotti', 3, 1),
(16, 2, 'Succhi di frutta', 2, 1),
(17, 2, 'Yogurt', 4, 0),
(18, 3, 'Acqua', 6, 1),
(19, 3, 'Vino', 2, 0),
(20, 1, 'Insalata', 1, 0),
(21, 1, 'Salse', 2, 1),
(22, 2, 'Sottaceti', 3, 1),
(23, 2, 'Sapone', 1, 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `family`
--

CREATE TABLE `family` (
  `id_famiglia` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `family`
--

INSERT INTO `family` (`id_famiglia`, `nome`) VALUES
(1, 'Nasatti'),
(2, 'Previtali');

-- --------------------------------------------------------

--
-- Struttura della tabella `shopping`
--

CREATE TABLE `shopping` (
  `id_spesa` int(11) NOT NULL,
  `data` date NOT NULL,
  `id_famiglia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `shopping`
--

INSERT INTO `shopping` (`id_spesa`, `data`, `id_famiglia`) VALUES
(1, '2023-05-16', 1),
(2, '2023-05-16', 2),
(3, '2023-05-11', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `user`
--

CREATE TABLE `user` (
  `id_utente` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `cognome` varchar(50) NOT NULL,
  `email` varchar(255) NOT NULL,
  `id_famiglia` int(11) NOT NULL,
  `psw` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `user`
--

INSERT INTO `user` (`id_utente`, `nome`, `cognome`, `email`, `id_famiglia`, `psw`) VALUES
(1, 'Riccardo', 'Nasatti', 'riccardonasatti@gmail.com', 1, 'Riccardo'),
(2, 'Matteo', 'Nasatti', 'matteonasa@gmail.com', 1, 'Matteo'),
(3, 'Dario', 'Previtali', 'darioprev@gmail.com', 2, 'Dario'),
(4, 'Giacomo', 'Previtali', 'giacomoprev@gmail.com', 2, 'Giacomo');

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`id_articolo`),
  ADD KEY `id_spesa` (`id_spesa`);

--
-- Indici per le tabelle `family`
--
ALTER TABLE `family`
  ADD PRIMARY KEY (`id_famiglia`);

--
-- Indici per le tabelle `shopping`
--
ALTER TABLE `shopping`
  ADD PRIMARY KEY (`id_spesa`),
  ADD KEY `famiglia` (`id_famiglia`);

--
-- Indici per le tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_utente`),
  ADD KEY `id_famiglia` (`id_famiglia`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `article`
--
ALTER TABLE `article`
  MODIFY `id_articolo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT per la tabella `family`
--
ALTER TABLE `family`
  MODIFY `id_famiglia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT per la tabella `shopping`
--
ALTER TABLE `shopping`
  MODIFY `id_spesa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `user`
--
ALTER TABLE `user`
  MODIFY `id_utente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `article`
--
ALTER TABLE `article`
  ADD CONSTRAINT `id_spesa` FOREIGN KEY (`id_spesa`) REFERENCES `shopping` (`id_spesa`);

--
-- Limiti per la tabella `shopping`
--
ALTER TABLE `shopping`
  ADD CONSTRAINT `famiglia` FOREIGN KEY (`id_famiglia`) REFERENCES `family` (`id_famiglia`);

--
-- Limiti per la tabella `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `id_famiglia` FOREIGN KEY (`id_famiglia`) REFERENCES `family` (`id_famiglia`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

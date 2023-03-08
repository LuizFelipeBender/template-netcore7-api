using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateApiDDD.Migrations
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"INSERT INTO `database-1`.`dono` (`Nome`, `Email`, `Celular`, `Cpf`) VALUES ('Luiz Bender', 'Bender@gmail.com', '49123123312', '90182121212');
                                    INSERT INTO `database-1`.`dono` ( `Nome`, `Email`, `Celular`, `Cpf`) VALUES ('Maria Midlands', 'Maria123@gmail.com', '49988832122', '11198765432');
                                    INSERT INTO `database-1`.`dono` (`Nome`, `Email`, `Celular`, `Cpf`) VALUES ('Lucas Vasconcelos', 'Luca@gmail.com', '49123123312', '12321123131');
                                    INSERT INTO `database-1`.`dono` (`Nome`, `Email`, `Celular`, `Cpf`) VALUES ('Filipe Philips', 'Filipi@Yahoo.com.br', '49111111111', '12345678910');
                                    INSERT INTO `database-1`.`dono` (`Nome`, `Email`, `Celular`, `Cpf`) VALUES ('Vanessa Stranger', 'StrangerV@GFT.com', '32911111111', '11111111111');
                                    INSERT INTO `database-1`.`pet` (`Nome`, `Altura`, `Peso`, `Idade`, `Raca`) VALUES ('Konder', '123cm', '200cm', '10', 'Puddle');
                                    INSERT INTO `database-1`.`pet` (`Nome`, `Altura`, `Peso`, `Idade`, `Raca`) VALUES ('Atlas', '200cm', '300cm', '13', 'Pitbull');
                                    INSERT INTO `database-1`.`pet` (`Nome`, `Altura`, `Peso`, `Idade`, `Raca`) VALUES ('Zeus', '170cm', '230cm', '14', 'Pincher');
                                    INSERT INTO `database-1`.`pets_donos` (`Id_Pet`, `Id_Dono`) VALUES ('1', '5');
                                    INSERT INTO `database-1`.`pets_donos` (`Id_Pet`, `Id_Dono`) VALUES ('1', '3');
                                    INSERT INTO `database-1`.`pets_donos` (`Id_Pet`, `Id_Dono`) VALUES ('1', '4');
                                    INSERT INTO `database-1`.`pets_donos` (`Id_Pet`, `Id_Dono`) VALUES ('2', '1');
                                    INSERT INTO `database-1`.`pets_donos` (`Id_Pet`, `Id_Dono`) VALUES ('3', '2');
                                    INSERT INTO `database-1`.`profissional` (`Nome`, `Email`, `Celular`, `Cpf`, `CRV`, `Ativo`) VALUES ('Michele Delatorre', 'DelaTorreMichel@medVeterinaria.com', '(42) 98822-8484', '83692605943', '9633799', '1');
                                    INSERT INTO `database-1`.`profissional` (`Nome`, `Email`, `Celular`, `Cpf`, `CRV`, `Ativo`) VALUES ('Diego Samuel Heitor Monteiro', 'diego.samuel.monteiro@ygui.com.br', '(91) 98909-5295', '52114179176', '6836470', '1');
                                    INSERT INTO `database-1`.`tipoatendimento` (`Nome`, `Ativa`) VALUES ('Atendimentos cirugicos', '1');
                                    INSERT INTO `database-1`.`tipoatendimento` (`Nome`, `Ativa`) VALUES ('Atendimento cardiológico', '1');
                                    INSERT INTO `database-1`.`tipoatendimento` (`Nome`, `Ativa`) VALUES ('Atendimento para fraturas  ', '1');
                                    INSERT INTO `database-1`.`tipoatendimento` (`Nome`, `Ativa`) VALUES ('Exames de sangue', '1');
                                    INSERT INTO `database-1`.`tipoatendimento` (`Nome`, `Ativa`) VALUES ('Exames de ultrassom e raio-x', '1');
                                    INSERT INTO `database-1`.`profissional_tipoatendimento` (`Id_profissional`, `Id_tipoAtendimento`) VALUES ('1', '2');
                                    INSERT INTO `database-1`.`profissional_tipoatendimento` (`Id_profissional`, `Id_tipoAtendimento`) VALUES ('1', '4');
                                    INSERT INTO `database-1`.`profissional_tipoatendimento` (`Id_profissional`, `Id_tipoAtendimento`) VALUES ('1', '1');
                                    INSERT INTO `database-1`.`profissional_tipoatendimento` (`Id_profissional`, `Id_tipoAtendimento`) VALUES ('2', '3');
                                    INSERT INTO `database-1`.`profissional_tipoatendimento` (`Id_profissional`, `Id_tipoAtendimento`) VALUES ('2', '2');
");

    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
}

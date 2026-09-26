--Script sp Animal

use Agraria;
go

create or alter procedure sp_selectanimal
as
begin
    set nocount on;

    select 
        a.id_animal as idanimal,
        a.nombre_comun as nombrecomun,
        a.nombre_cientifico as nombrecientifico,
        a.id_tipo as idtipo,
        a.id_rubro as idrubro,
        a.id_subrubro as idsubrubro,
        t.nombre as tipo_animal,
        r.nombre as rubro,
        sr.nombre as subrubro,
        a.fecha_nacimiento as fechanacimiento,
        a.sexo as sexo
    from animal a
    left join tipo_animal t on a.id_tipo = t.id_tipo_animal
    left join rubro r on a.id_rubro = r.id_rubro
    left join subrubro sr on a.id_subrubro = sr.id_subrubro;
end;
go


create or alter procedure sp_select_ultimo_id_animal
    @min bigint,
    @max bigint
as
begin
    set nocount on;

    select isnull(max(id_animal), 0)
    from animal
    where id_animal >= @min and id_animal <= @max;
end;
go


create or alter procedure sp_insertanimal
    @id_animal bigint,
    @nombre_comun varchar(100),
    @nombre_cientifico varchar(150) = null,
    @id_tipo int,
    @id_rubro int,
    @id_subrubro int,
    @fecha_nacimiento date,
    @sexo varchar(20)
as
begin
    set nocount on;

    insert into animal (
        id_animal,
        nombre_comun,
        nombre_cientifico,
        id_tipo,
        id_rubro,
        id_subrubro,
        fecha_nacimiento,
        sexo
    )
    values (
        @id_animal,
        @nombre_comun,
        @nombre_cientifico,
        @id_tipo,
        @id_rubro,
        @id_subrubro,
        @fecha_nacimiento,
        @sexo
    );
end;
go


create or alter procedure sp_updateanimal
    @id_animal bigint,
    @nombre_comun varchar(100),
    @nombre_cientifico varchar(150) = null,
    @id_tipo int,
    @id_rubro int,
    @id_subrubro int,
    @fecha_nacimiento date,
    @sexo varchar(20)
as
begin
    set nocount on;

    update animal
    set nombre_comun = @nombre_comun,
        nombre_cientifico = @nombre_cientifico,
        id_tipo = @id_tipo,
        id_rubro = @id_rubro,
        id_subrubro = @id_subrubro,
        fecha_nacimiento = @fecha_nacimiento,
        sexo = @sexo
    where id_animal = @id_animal;
end;
go


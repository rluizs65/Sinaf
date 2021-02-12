using System;
using AutoMapper;
using Sinaf.Domain.Data.Entities;
using Sinaf.DTO.Responses;
using Sinaf.DTO.Responses;

namespace Sinaf.Domain.Mappers
{
    public class EntityToDtoMappingProfile : Profile, IEntityToDtoMappingProfile
    {
        public EntityToDtoMappingProfile()
        {
            ApoliceMapper();
            ClienteMapper();
            CorretorMapper();
            PessoaMapper();
            PessoaEnderecoMapper();
        }

        public TEntity CheckEntity<TEntity>(TEntity entity) where TEntity : new()
        {
            TEntity result = entity;
            if (result == null) result = new TEntity();

            return result;
        }

        public void ApoliceMapper()
        {
            Func<ApoliceEntity, ApoliceResponseDTO, ApoliceResponseDTO> conversion 
                = delegate (ApoliceEntity src, ApoliceResponseDTO dest)
            {
                dest = new ApoliceResponseDTO
                {
                    IdApolice = src.Id,
                    NumeroApolice = src.Numero,
                    DataInicioVigencia = src.DataInicioVigencia,
                    DataFimVigencia = src.DataFimVigencia,
                    IdProposta = CheckEntity(src.Proposta).Id,
                    NumeroProposta = CheckEntity(src.Proposta).Numero
                };
                return dest;
            };

            var map = CreateMap<ApoliceEntity, ApoliceResponseDTO>();
            map.ConvertUsing(conversion);
        }

        public void ClienteMapper()
        {
            Func<ClienteEntity, GetClienteResponseDTO, GetClienteResponseDTO> conversion
                = delegate (ClienteEntity src, GetClienteResponseDTO dest)
                {
                    dest = new GetClienteResponseDTO
                    {
                        IdCliente = src.Id,
                        IdPessoa = CheckEntity(src.Pessoa).Id,
                        Nome = CheckEntity(src.Pessoa).Nome,
                        Cpf = CheckEntity(src.Pessoa).Cpf,
                        DataNascimento = CheckEntity(src.Pessoa).DataNascimento,
                        Sexo = CheckEntity(src.Pessoa).Sexo,
                        Email = CheckEntity(src.Pessoa).Email
                    };
                    return dest;
                };

            var map = CreateMap<ClienteEntity, GetClienteResponseDTO>();
            map.ConvertUsing(conversion);
        }

        public void CorretorMapper()
        {
            Func<CorretorEntity, CorretorResponseDTO, CorretorResponseDTO> conversion
                = delegate (CorretorEntity src, CorretorResponseDTO dest)
                {
                    dest = new CorretorResponseDTO
                    {
                        IdCorretor = src.Id,
                        IdPessoa = CheckEntity(src.Pessoa).Id,
                        Codigo = src.Codigo,
                        Nome = CheckEntity(src.Pessoa).Nome,
                        Cpf = CheckEntity(src.Pessoa).Cpf,
                        DataNascimento = CheckEntity(src.Pessoa).DataNascimento,
                        Sexo = CheckEntity(src.Pessoa).Sexo,
                        Email = CheckEntity(src.Pessoa).Email
                    };
                    return dest;
                };

            var map = CreateMap<CorretorEntity, CorretorResponseDTO>();
            map.ConvertUsing(conversion);
        }

        public void PessoaMapper()
        {
            Func<PessoaEntity, PessoaResponseDTO, PessoaResponseDTO> conversion
                = delegate (PessoaEntity src, PessoaResponseDTO dest)
                {
                    dest = new PessoaResponseDTO
                    {
                        IdPessoa = src.Id,
                        Nome = src.Nome,
                        Cpf = src.Cpf,
                        Cnpj = src.Cnpj,
                        DataNascimento = src.DataNascimento,
                        Sexo = src.Sexo,
                        Email = src.Email
                    };
                    return dest;
                };

            var map = CreateMap<PessoaEntity, PessoaResponseDTO>();
            map.ConvertUsing(conversion);
        }

        public void PessoaEnderecoMapper()
        {
            Func<PessoaEnderecoEntity, PessoaEnderecoResponseDTO, PessoaEnderecoResponseDTO> conversion
                = delegate (PessoaEnderecoEntity src, PessoaEnderecoResponseDTO dest)
                {
                    dest = new PessoaEnderecoResponseDTO
                    {
                        IdPessoaEndereco = src.Id,
                        Endereco = src.Endereco,
                        Numero = src.Numero,
                        Complemento = src.Complemento,
                        Cep = src.Cep,
                        Uf = src.Uf,
                        Cidade = src.Cidade,
                        Bairro = src.Bairro,
                        IdPessoa = CheckEntity(src.Pessoa).Id
                    };
                    return dest;
                };

            var map = CreateMap<PessoaEnderecoEntity, PessoaEnderecoResponseDTO>();
            map.ConvertUsing(conversion);
        }
    }
}

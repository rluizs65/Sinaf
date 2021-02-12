using System;
using AutoMapper;
using Sinaf.Domain.Data.Entities;
using Sinaf.DTO.Requests;
using Sinaf.DTO.Responses;

namespace Sinaf.Domain.Mappers
{
    public class DtoToEntityMappingProfile : Profile, IDtoToEntityMappingProfile
    {
        public DtoToEntityMappingProfile()
        {
            ClienteMapper();
            AddPessoaMapper();
            UpdatePessoaMapper();
        }

        public void ClienteMapper()
        {
            Func<GetClienteResponseDTO, ClienteEntity, ClienteEntity> conversion = 
                delegate (GetClienteResponseDTO src, ClienteEntity dest)
            {
                dest = new ClienteEntity
                {
                    Id = src.IdCliente,
                    Pessoa = new PessoaEntity
                    {
                        Id = src.IdPessoa,
                        Nome = src.Nome,
                        Cpf = src.Cpf,
                        DataNascimento = src.DataNascimento,
                        Sexo = src.Sexo,
                        Email = src.Email
                    }
                };

                return dest;
            };

            var map = CreateMap<GetClienteResponseDTO, ClienteEntity>();
            map.ConvertUsing(conversion);
        }

        public void AddPessoaMapper()
        {
            Func<AddPessoaRequestDTO, PessoaEntity, PessoaEntity> conversion =
                delegate (AddPessoaRequestDTO src, PessoaEntity dest)
                {
                    dest = new PessoaEntity
                    {
                        Nome = src.Nome,
                        Cpf = src.Cpf,
                        Cnpj = src.Cnpj,
                        DataNascimento = src.DataNascimento,
                        Sexo = src.Sexo,
                        Email = src.Email
                    };

                    return dest;
                };

            var map = CreateMap<AddPessoaRequestDTO, PessoaEntity>();
            map.ConvertUsing(conversion);
        }

        public void UpdatePessoaMapper()
        {
            Func<UpdatePessoaRequestDTO, PessoaEntity, PessoaEntity> conversion =
                delegate (UpdatePessoaRequestDTO src, PessoaEntity dest)
                {
                    dest = new PessoaEntity
                    {
                        Id = src.IdPessoa,
                        Nome = src.Nome,
                        Cpf = src.Cpf,
                        Cnpj = src.Cnpj,
                        DataNascimento = src.DataNascimento,
                        Sexo = src.Sexo,
                        Email = src.Email
                    };

                    return dest;
                };

            var map = CreateMap<UpdatePessoaRequestDTO, PessoaEntity>();
            map.ConvertUsing(conversion);
        }
    }

}

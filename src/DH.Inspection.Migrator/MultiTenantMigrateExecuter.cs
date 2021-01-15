using System;
using System.Collections.Generic;
using System.Data.Common;
using Abp.Data;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using DH.Inspection.EntityFrameworkCore;
using DH.Inspection.EntityFrameworkCore.Seed;
using DH.Inspection.MultiTenancy;

namespace DH.Inspection.Migrator
{
    public class MultiTenantMigrateExecuter : ITransientDependency
    {
        private readonly Log _log;
        private readonly AbpZeroDbMigrator _migrator;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IDbPerTenantConnectionStringResolver _connectionStringResolver;

        public MultiTenantMigrateExecuter(
            AbpZeroDbMigrator migrator,
            IRepository<Tenant> tenantRepository,
            Log log,
            IDbPerTenantConnectionStringResolver connectionStringResolver)
        {
            _log = log;

            _migrator = migrator;
            _tenantRepository = tenantRepository;
            _connectionStringResolver = connectionStringResolver;
        }

        public bool Run(bool skipConnVerification)
        {
            var hostConnStr = CensorConnectionString(_connectionStringResolver.GetNameOrConnectionString(new ConnectionStringResolveArgs(MultiTenancySides.Host)));
            if (hostConnStr.IsNullOrWhiteSpace())
            {
                _log.Write("�����ļ�Ӧ������Ϊ��Default���������ַ��� ");
                return false;
            }

            _log.Write("Host database: " + ConnectionStringHelper.GetConnectionString(hostConnStr));
            if (!skipConnVerification)
            {
                _log.Write("����Ǩ�ƴ��������ݿ�������⻧����������/�񣩣�");
                var command = Console.ReadLine();
                if (!command.IsIn("Y", "y"))
                {
                    _log.Write("Ǩ����ȡ��.");
                    return false;
                }
            }

            _log.Write("�������ݿ�Ǩ��������...");

            try
            {
                _migrator.CreateOrMigrateForHost(SeedHelper.SeedHostDb);
            }
            catch (Exception ex)
            {
                _log.Write("Ǩ���������ݿ�ʱ����:");
                _log.Write(ex.ToString());
                _log.Write("��ȡ��Ǩ��.");
                return false;
            }

            _log.Write("�������ݿ�Ǩ�������.");
            _log.Write("--------------------------------------------------------");

            var migratedDatabases = new HashSet<string>();
            var tenants = _tenantRepository.GetAllList(t => t.ConnectionString != null && t.ConnectionString != "");
            for (var i = 0; i < tenants.Count; i++)
            {
                var tenant = tenants[i];
                _log.Write(string.Format("�⻧���ݿ�Ǩ��������... ({0} / {1})", (i + 1), tenants.Count));
                _log.Write("Name              : " + tenant.Name);
                _log.Write("TenancyName       : " + tenant.TenancyName);
                _log.Write("Tenant Id         : " + tenant.Id);
                _log.Write("Connection string : " + SimpleStringCipher.Instance.Decrypt(tenant.ConnectionString));

                if (!migratedDatabases.Contains(tenant.ConnectionString))
                {
                    try
                    {
                        _migrator.CreateOrMigrateForTenant(tenant);
                    }
                    catch (Exception ex)
                    {
                        _log.Write("Ǩ���⻧���ݿ�ʱ����:");
                        _log.Write(ex.ToString());
                        _log.Write("���������⻧������Ϊ�����⻧����...");
                    }

                    migratedDatabases.Add(tenant.ConnectionString);
                }
                else
                {
                    _log.Write("�����ݿ���ǰ��Ǩ�ƣ�ͬһ���ݿ����ж���⻧����������....");
                }

                _log.Write(string.Format("�⻧���ݿ�Ǩ�������. ({0} / {1})", (i + 1), tenants.Count));
                _log.Write("--------------------------------------------------------");
            }

            _log.Write("All databases have been migrated.");

            return true;
        }

        private static string CensorConnectionString(string connectionString)
        {
            var builder = new DbConnectionStringBuilder { ConnectionString = connectionString };
            var keysToMask = new[] { "password", "pwd", "user id", "uid" };

            foreach (var key in keysToMask)
            {
                if (builder.ContainsKey(key))
                {
                    builder[key] = "*****";
                }
            }

            return builder.ToString();
        }
    }
}

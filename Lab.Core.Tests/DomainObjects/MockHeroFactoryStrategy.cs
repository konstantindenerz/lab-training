﻿using System;
using Lab.Core.DomainObjects;
using Lab.Core.DomainObjects.Serialization;
using Lab.Core.DomainObjects.Serialization.Internal;
using Lab.Core.Tests.DomainObjects.Serialization;

namespace Lab.Core.Tests.DomainObjects
{
    class MockHeroFactoryStrategy : IObjectFactoryStrategy
    {
        public IObjectBase Execute(string name)
        {
            IObjectBase result = new MockDeadpool();

            IJsonSerializer serializer = null;

            switch ((EMockHeroFactoryStrategy)Enum.Parse(typeof(EMockHeroFactoryStrategy), name))
            {
                case EMockHeroFactoryStrategy.deadPoolWithMockSerializer:
                    var deadpool = new MockDeadpool();
                    serializer = new MockJsonSerializer(deadpool);
                    deadpool.Json = serializer;
                    result = deadpool;
                    break;

                case EMockHeroFactoryStrategy.deadPoolWithSerializer:
                    var otherDeadpool = new MockDeadpool();
                    serializer = new JsonSerializer(otherDeadpool);
                    otherDeadpool.Json = serializer;
                    result = otherDeadpool;
                    break;

                case EMockHeroFactoryStrategy.mockObject:
                    var mockObject = new MockObject();
                    serializer = new JsonSerializer(mockObject);
                    mockObject.Json = serializer;
                    result = mockObject;
                    break;

                case EMockHeroFactoryStrategy.mockHero:
                    var mockHero = new MockHero();
                    serializer = new JsonSerializer(mockHero);
                    mockHero.Json = serializer;
                    result = mockHero;
                    break;
            }
            return result;
        }
    }
}

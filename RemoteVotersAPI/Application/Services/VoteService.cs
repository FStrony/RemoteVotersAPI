﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;
using RemoteVotersAPI.Infra.Data.Repositories;
using RemoteVotersAPI.Infra.ModelSettings;

namespace RemoteVotersAPI.Application.Services
{
    /// <summary>
    /// Vote Service
    ///
    /// Author: FStrony
    /// </summary>
    public class VoteService
    {
        /// <value>vote repository</value>
        private VoteRepository voteRepository;

        /// <value>MongoDB configs</value>
        private IOptions<MongoDBConfig> mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public VoteService(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.voteRepository = new VoteRepository(mongoDBConfig);
        }

        /// <summary>
        /// Delete All Votes By Company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteAllVotesByCompanyId(ObjectId companyId)
        {
            await voteRepository.DeleteAllByCompanyId(companyId);
        }

        /// <summary>
        /// Delete All Votes By Company ID and Campaign ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task DeleteAllVotes(ObjectId companyId, ObjectId campaignId)
        {
            await voteRepository.DeleteAll(companyId, campaignId);
        }

        /// <summary>
        /// Register Vote
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task RegisterVote(VoteViewModel record)
        {
            await voteRepository.RegisterVote(Mapper.Map<Vote>(record));
        }

        /// <summary>
        /// Retrieve Results
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Result List</returns>
        public async Task<List<VoteViewModel>> RetrieveResults(ObjectId companyId, ObjectId campaignId)
        {
            return Mapper.Map<List<VoteViewModel>>(await voteRepository.RetrieveResults(companyId, campaignId));
        }

        /// <summary>
        /// Checks if the voter already voted in the campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="voterIdentity"></param>
        /// <returns>bool</returns>
        public async Task<bool> HasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await voteRepository.HasAlreadyVoted(campaignId, voterIdentity);
        }
    }
}

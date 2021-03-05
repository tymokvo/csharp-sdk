using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PollinationSDK.Api;


namespace PollinationSDK.Test
{
    [TestFixture]
    public class ProjectsApiTests
    {
        private ProjectsApi api;
        private string NewProject = "MyNewProjectTest2";
        private Project Project;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            api = new ProjectsApi();
            Project = CreateProject(NewProject);
           

        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [OneTimeTearDown]
        public void Cleanup()
        {
            DeleteProject(NewProject);
        }


        
        public Project CreateProject(string projName)
        {
            var projs = api.ListProjects(owner: new List<string>() { Helper.CurrentUser.Username }).Resources;
            var found = projs.FirstOrDefault(_ => _.Name == this.NewProject);

            var owner = Helper.CurrentUser.Username;
            var projectCreate = new ProjectCreate(projName);
            var response = api.CreateProject(owner, projectCreate);
            var proj = api.GetProject(owner, projName);
            return proj;
        }

        public void DeleteProject(string projName)
        {
            var owner = Helper.CurrentUser.Username;
            api.DeleteProject(owner, projName);
            
        }

        [Test]
        public void CreateProjectRecipeFilterTest()
        {
            //ISSUE: https://github.com/pollination/pollination-server/issues/128

            //var response = JobRunner.CheckRecipeInProject("ladybug-tools", "daylight-factor", this.Project);
            //Assert.IsTrue(!string.IsNullOrEmpty( response));

            //// delete recipe filter test
            //var projectRecipeFilter = new ProjectRecipeFilter("ladybug-tools", "daylight-factor");
            //instance.DeleteProjectRecipeFilter(this.Project.Owner.Name, this.Project.Name, projectRecipeFilter);
        }
        

       
        
        
        /// <summary>
        /// Test ListProjects
        /// </summary>
        [Test]
        public void ListProjectsTest()
        {
            var response = api.ListProjects(owner: new List<string>() {Helper.CurrentUser.Username });
            var projs = response.Resources;
            Assert.IsTrue(projs.Count > 1);

            var found = projs.FirstOrDefault(_ => _.Name == this.NewProject);
            Assert.IsTrue(found != null);
        }
        
        
        
    }

}

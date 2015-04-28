/// <binding AfterBuild='default' />
// This file in the main entry point for defining grunt tasks and using grunt plugins.
// Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409

module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
		bowercopy: {
            options: {
                runBower: true,
                destPrefix: 'wwwroot/lib'
            },
            libs: {
                files: {
                    'angular': 'angular',
                    'angular-route': 'angular-route',
                    'jquery': 'jquery',
                    'bootstrap': 'bootstrap/dist/css'
                }
            }
        },
		clean:{
			dist: ["wwwroot/dist"]
		},
		copy: {
            main: {
                expand: true,
                flatten: true,
                filter: 'isFile',
                src: ['App/Scripts/*.js'],
                dest: 'wwwroot/dist/'
            }
        },
		concat: {
			options: {
				separator: ''
			},
			dist: {
				src: ['wwwroot/dist/*.js'],
				dest: 'wwwroot/dist/appCombined.js'
			}
		},
		html2js:{
			options: {
			  module:'virtualTrainingTemplates',
			  base:'.'
			},
			main: {
			  src: ['App/Templates/*.html'],
			  dest: 'wwwroot/dist/templates.js'
			}
		}
    });

    // This command registers the default task which will install bower packages into wwwroot/lib
    grunt.registerTask("default", ["clean", "bowercopy:libs","html2js", "copy:main", "concat"]);

    // The following line loads the grunt plugins.
    // This line needs to be at the end of this this file.
    grunt.loadNpmTasks("grunt-bower-task");
	grunt.loadNpmTasks("grunt-bowercopy");
	grunt.loadNpmTasks("grunt-contrib-copy");
	grunt.loadNpmTasks("grunt-contrib-clean");
	grunt.loadNpmTasks("grunt-contrib-concat");
	grunt.loadNpmTasks("grunt-html2js");
};
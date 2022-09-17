#pragma once
#include <string>
#include <vector>
#include "EnumsAndStructures.h"
#include "TaskKoshi.h"
#include "Solver.h"

class FarmSolvers
{
public:	
	void CheckNameRepeat(const std::string& Name)const;
	void DetermeningTheExistenceSolvers(const std::string& Name)const;
	void IsArraySolversEmpty()const;

	void AddSolver(FarmSolvers);
	void SolveProblem(Solver*, TaskKoshi&);
	void DeleteSolver(std::string&);

	Points GetResults(const std::string& Name)const;
	Points GetPoints()const;
	std::string GetName()const;

	FarmSolvers(){}
	FarmSolvers(std::string N)
		:Name(N) {}

private:
	std::string Name;
	Points Point;
	std::vector <FarmSolvers> ArraySolvers;
};

#pragma once
#include "TaskKoshi.h"
#include "FarmSolvers.h"


class SolverMethodHoina : public FarmSolvers
{
public:
	void SolverKoshiTask(const TaskKoshi&);
};
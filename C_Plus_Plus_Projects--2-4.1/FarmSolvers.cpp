#include "FarmSolvers.h"
#include <iostream>

void FarmSolvers::CheckNameRepeat(const std::string& Name) const // �������� ��� ����� ����� ����������� ��� ������� ������ 
{
	for (int i = 0; i < ArraySolversEulerMethod.size(); i++) // �������� �� ������� ����� ��� ���
		if (ArraySolversEulerMethod[i].GetName() == Name)
			throw Errors();// ����������

	for ( int i = 0; i < ArraySolversMethodHoina.size(); i++)
		if (ArraySolversMethodHoina[i].GetName() == Name)
			throw Errors(); // ����������
}

void FarmSolvers::AddSolverEulerMethod(const std::string& Name, const BehaviorOfSolver& Behavior)
{
	// ������� ������ ����� ������ � ��������� ��� ���
	SolverEulerMethod Solver(Name, Behavior);
	ArraySolversEulerMethod.push_back(Solver); //����������� �������� �����������
}

void FarmSolvers::AddSolverMethodHoina(const std::string& Name, const BehaviorOfSolver& Behavior)
{
	// ������� ������ ����� ������ � ��������� ��� ���
	SolverMethodHoina Solver(Name, Behavior);
	ArraySolversMethodHoina.push_back(Solver);
}

void FarmSolvers::SolveProblem(const TaskKoshi& Task)
{
	unsigned int i = 0;

	for (i = 0; i < ArraySolversEulerMethod.size(); i++) // ���� �� ������� ������ ����, ��� ������� �� ��������� ������� ������
		ArraySolversEulerMethod[i].SolverKoshiTask(Task);

	for (i = 0; i < ArraySolversMethodHoina.size(); i++) // ���� �� ������� ������ ����, ��� ������� �� ��������� ������� �����		
		ArraySolversMethodHoina[i].SolverKoshiTask(Task);

}

Points FarmSolvers::GetResults(const std::string&) const
{
	for (int i = 0; i < ArraySolversEulerMethod.size(); i++)
		if (ArraySolversEulerMethod[i].GetName() == Name)
			return ArraySolversEulerMethod[i].GetPoints();

	for (int i = 0; i < ArraySolversMethodHoina.size(); i++)
		if (ArraySolversMethodHoina[i].GetName() == Name)
			return ArraySolversMethodHoina[i].GetPoints();
}

BehaviorOfSolver FarmSolvers::GetBehavior() const
{
	return Behavior;
}

std::string FarmSolvers::GetName() const
{
	return std::string(Name);
}

Points FarmSolvers::GetPoints() const
{
	return Point;
}